using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands;
using PunchesManagement.DataAccess.CQRS.Queries.UsersQuery;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AddUserHandler(
        IMapper mapper, 
        ICommandExecutor commandExecutor, 
        IQueryExecutor queryExecutor,
        IPasswordHasher<User> passwordHasher)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
        _passwordHasher = passwordHasher;
    }

    public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery()
        {
            UserName = request.Username
        };

        var getUser = await _queryExecutor.Execute(query);

        if (getUser != null)
        {
            if (getUser.UserName == request.Username)
            {
                return new AddUserResponse()
                {
                    Error = new ErrorModel(ErrorType.ValidationError + "! This login is already taken.")
                };
            }

            return new AddUserResponse()
            {
                Error = new ErrorModel(ErrorType.Conflict)
            };
        }

        request.Password = _passwordHasher.HashPassword(getUser, request.Password);

        var user = _mapper.Map<DataAccess.Entities.User>(request);

        var command = new AddUserCommand() 
        { 
            Parameter = user 
        };

        var userFromDb = await _commandExecutor.Execute(command);
        
        var response =  new AddUserResponse()
        {
            Data = _mapper.Map<Domain.Models.User>(userFromDb)
        };

        return response;
    }
}

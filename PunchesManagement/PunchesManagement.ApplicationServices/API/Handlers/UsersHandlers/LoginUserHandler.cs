using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.Models;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries.UsersQuery;
using PunchesManagement.DataAccess.Entities;
using System.Security.Claims;

namespace PunchesManagement.ApplicationServices.API.Handlers.UsersHandlers;

public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;
    private readonly IPasswordHasher<DataAccess.Entities.User> _passwordHasher;
    //private readonly AuthenticationSettings _authenticationSettings;

    public LoginUserHandler(
        IMapper mapper,
        ICommandExecutor commandExecutor,
        IQueryExecutor queryExecutor,
        IPasswordHasher<DataAccess.Entities.User> passwordHasher)
        //AuthenticationSettings authenticationSettings)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
        _passwordHasher = passwordHasher;
        //_authenticationSettings = authenticationSettings;
    }

    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery()
        {
            UserName = request.UserName
        };

        var getUser = await _queryExecutor.Execute(query);

        if (getUser is null)
        {
            return new LoginUserResponse()
            {
                Error = new ErrorModel(ErrorType.InvalidIncomingData)
            };
        }

        var result = _passwordHasher.VerifyHashedPassword(getUser, getUser.PasswordHash, request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return new LoginUserResponse()
            {
                Error = new ErrorModel(ErrorType.InvalidIncomingData)
            };
        }

        var mappedUser = _mapper.Map<Domain.Models.User>(getUser);
        var response = new LoginUserResponse()
        {
            Data = mappedUser
        };
        return response;
    }
}

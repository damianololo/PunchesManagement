using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands;
using PunchesManagement.DataAccess.CQRS.Queries.UsersQuery;

namespace PunchesManagement.ApplicationServices.API.Handlers.UsersHandlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateUserHandler(
    IMapper mapper,
    IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery()
        {
            SearchId = request.UpdateId
        };
        var getUser = await _queryExecutor.Execute(query);

        if (getUser is null)
        {
            return new UpdateUserResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedUser = _mapper.Map<DataAccess.Entities.User>(request);

        var command = new UpdateUserCommand()
        {
            Parameter = mappedUser,
        };

        var updatedUser = await _commandExecutor.Execute(command);

        var response = new UpdateUserResponse()
        {
            Data = _mapper.Map<Domain.Models.User>(updatedUser)
        };

        return response;
    }
}

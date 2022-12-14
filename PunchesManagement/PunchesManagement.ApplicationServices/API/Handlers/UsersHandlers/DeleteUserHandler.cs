using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands;
using PunchesManagement.DataAccess.CQRS.Queries.UsersQuery;

namespace PunchesManagement.ApplicationServices.API.Handlers.UsersHandlers;

public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
	private readonly IMapper _mapper;
	private readonly ICommandExecutor _commandExecutor;
	private readonly IQueryExecutor _queryExecutor;

	public DeleteUserHandler(IMapper mapper,
        ICommandExecutor commandExecutor,
        IQueryExecutor queryExecutor)
    {
		_mapper = mapper;
		_commandExecutor = commandExecutor;
		_queryExecutor = queryExecutor;
	}

	public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
	{
        var query = new GetUserByIdQuery()
        {
            SearchId = request.DeleteId
        };
        var user = await _queryExecutor.Execute(query);

        if (user is null)
        {
            return new DeleteUserResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedUser = _mapper.Map<DataAccess.Entities.User>(request);
        var command = new DeleteUserCommand()
        {
            Parameter = mappedUser
        };
        var deleteUser = await _commandExecutor.Execute(command);
        var response = new DeleteUserResponse()
        {
            Data = _mapper.Map<Domain.Models.User>(deleteUser)
        };
        return response;
    }
}

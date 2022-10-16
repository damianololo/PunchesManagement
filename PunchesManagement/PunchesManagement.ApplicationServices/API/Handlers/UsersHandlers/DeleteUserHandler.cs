using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands;

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

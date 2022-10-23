using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.PunchesCommand;

namespace PunchesManagement.ApplicationServices.API.Handlers.PunchesHandlers;

public class DeletePunchesHandler : IRequestHandler<DeletePunchesRequest, DeletePunchesResponse>
{
	private readonly IMapper _mapper;
	private readonly ICommandExecutor _commandExecutor;
	private readonly IQueryExecutor _queryExecutor;

	public DeletePunchesHandler(IMapper mapper,
        ICommandExecutor commandExecutor,
        IQueryExecutor queryExecutor)
    {
		_mapper = mapper;
		_commandExecutor = commandExecutor;
		_queryExecutor = queryExecutor;
	}

	public async Task<DeletePunchesResponse> Handle(DeletePunchesRequest request, CancellationToken cancellationToken)
	{
		var mappedPunches = _mapper.Map<DataAccess.Entities.Punches>(request);
		var command = new DeletePunchesCommand()
		{
			Parameter = mappedPunches
		};
		var deletePunches = await _commandExecutor.Execute(command);
		var response = new DeletePunchesResponse()
		{
			Data = _mapper.Map<Domain.Models.Punches>(deletePunches)
		};
		return response;

    }
}

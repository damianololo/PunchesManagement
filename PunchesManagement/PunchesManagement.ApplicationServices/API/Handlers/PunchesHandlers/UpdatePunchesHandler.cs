using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.PunchesCommand;

namespace PunchesManagement.ApplicationServices.API.Handlers.PunchesHandlers;

public class UpdatePunchesHandler : IRequestHandler<UpdatePunchesRequest, UpdatePunchesResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;
    private readonly ICommandExecutor _commandExecutor;

    public UpdatePunchesHandler(
        IMapper mapper,
        IQueryExecutor queryExecutor,
        ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
        _commandExecutor = commandExecutor;
    }

    public async Task<UpdatePunchesResponse> Handle(UpdatePunchesRequest request, CancellationToken cancellationToken)
    {
        var mappedPunches = _mapper.Map<DataAccess.Entities.Punches>(request);
        var command = new UpdatePunchesCommand()
        {
            Parameter = mappedPunches,
        };
        var updatedPunches = await _commandExecutor.Execute(command);
        var response = new UpdatePunchesResponse()
        {
            Data = _mapper.Map<Domain.Models.Punches>(updatedPunches)
        };
        return response;
    }
}

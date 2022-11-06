using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.PunchesCommand;

namespace PunchesManagement.ApplicationServices.API.Handlers.PunchesHandlers;

public class AddPunchesHandler : IRequestHandler<AddPunchesRequest, AddPunchesResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddPunchesHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddPunchesResponse> Handle(AddPunchesRequest request, CancellationToken cancellationToken)
    {
        var punches = _mapper.Map<DataAccess.Entities.Punches>(request);

        var command = new AddPunchesCommand() 
        {
            Parameter = punches 
        };

        var punchesFromDb = await _commandExecutor.Execute(command);

        var response = new AddPunchesResponse()
        {
            Data = _mapper.Map<Domain.Models.Punches>(punchesFromDb)
        };

        return response;
    }
}

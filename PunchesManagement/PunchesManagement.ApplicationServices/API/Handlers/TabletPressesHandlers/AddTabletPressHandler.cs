using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.TabletPressCommand;

namespace PunchesManagement.ApplicationServices.API.Handlers.TabletPressesHandlers;

public class AddTabletPressHandler : IRequestHandler<AddTabletPressRequest, AddTabletPressResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;

    public AddTabletPressHandler(IMapper mapper, ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
    }

    public async Task<AddTabletPressResponse> Handle(AddTabletPressRequest request, CancellationToken cancellationToken)
    {
        var tabletPress = _mapper.Map<DataAccess.Entities.TabletPress>(request);
        var command = new AddTabletPressCommand() { Parameter = tabletPress };
        var tabletPressFromDb = await _commandExecutor.Execute(command);
        return new AddTabletPressResponse()
        {
            Data = _mapper.Map<Domain.Models.TabletPress>(tabletPressFromDb)
        };
    }
}

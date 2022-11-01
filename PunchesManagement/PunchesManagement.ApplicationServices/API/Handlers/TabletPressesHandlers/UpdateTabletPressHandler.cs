using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.TabletPressCommand;
using PunchesManagement.DataAccess.CQRS.Queries.TabletPressQuery;

namespace PunchesManagement.ApplicationServices.API.Handlers.TabletPressesHandlers;

public class UpdateTabletPressHandler : IRequestHandler<UpdateTabletPressRequest, UpdateTabletPressResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;
    private readonly ICommandExecutor _commandExecutor;

    public UpdateTabletPressHandler(
    IMapper mapper,
    IQueryExecutor queryExecutor,
    ICommandExecutor commandExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
        _commandExecutor = commandExecutor;
    }
    public async Task<UpdateTabletPressResponse> Handle(UpdateTabletPressRequest request, CancellationToken cancellationToken)
    {
        var query = new GetTabletPressByIdQuery()
        {
            SearchId = request.UpdateId,
        };
        var tabletPress = await _queryExecutor.Execute(query);

        if (tabletPress is null)
        {
            return new UpdateTabletPressResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedTabletPress = _mapper.Map<DataAccess.Entities.TabletPress>(request);
        var command = new UpdateTabletPressCommand()
        {
            Parameter = mappedTabletPress,
        };
        var updatedTabletPress = await _commandExecutor.Execute(command);
        var response = new UpdateTabletPressResponse()
        {
            Data = _mapper.Map<Domain.Models.TabletPress>(updatedTabletPress)
        };
        return response;
    }
}

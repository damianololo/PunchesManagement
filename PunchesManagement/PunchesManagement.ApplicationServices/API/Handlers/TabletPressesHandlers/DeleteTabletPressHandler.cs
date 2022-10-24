using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Commands.TabletPressCommand;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers.TabletPressesHandlers;

public class DeleteTabletPressHandler : IRequestHandler<DeleteTabletPressRequest, DeleteTabletPressResponse>
{
    private readonly IMapper _mapper;
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public DeleteTabletPressHandler(IMapper mapper,
    ICommandExecutor commandExecutor,
    IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _commandExecutor = commandExecutor;
        _queryExecutor = queryExecutor;
    }

    public async Task<DeleteTabletPressResponse> Handle(DeleteTabletPressRequest request, CancellationToken cancellationToken)
    {
        var query = new GetTabletPressByIdQuery()
        { 
            SearchId = request.DeleteId 
        };
        var tabletPress = await _queryExecutor.Execute(query);

        if (tabletPress is null)
        {
            return new DeleteTabletPressResponse()
            { 
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedTabletPress = _mapper.Map<DataAccess.Entities.TabletPress>(request);
        var command = new DeleteTabletPressCommand()
        {
            Parameter = mappedTabletPress
        };
        var deleteTabletPress = await _commandExecutor.Execute(command);
        var response = new DeleteTabletPressResponse()
        {
            Data = _mapper.Map<Domain.Models.TabletPress>(deleteTabletPress)
        };
        return response;
    }
}

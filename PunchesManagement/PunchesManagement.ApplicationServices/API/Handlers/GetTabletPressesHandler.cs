using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetTabletPressesHandler : IRequestHandler<GetTabletPressesRequest, GetTabletPressesResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetTabletPressesHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetTabletPressesResponse> Handle(GetTabletPressesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetTabletPressesQuery();
        var tabletPresses = await _queryExecutor.Execute(query);
        var mappedTabletPresses = _mapper.Map<List<Domain.Models.TabletPress>>(tabletPresses);
        var response = new GetTabletPressesResponse()
        {
            Data = mappedTabletPresses
        };
        return response;
    }
}

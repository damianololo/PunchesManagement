using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetPunchesHandler : IRequestHandler<GetPunchesRequest, GetPunchesResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetPunchesHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetPunchesResponse> Handle(GetPunchesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPunchesQuery();
        var punches = await _queryExecutor.Execute(query);
        var mappedPunches = _mapper.Map<List<Domain.Models.Punches>>(punches);
        var response = new GetPunchesResponse()
        {
            Data = mappedPunches 
        };
        return response;
    }
}

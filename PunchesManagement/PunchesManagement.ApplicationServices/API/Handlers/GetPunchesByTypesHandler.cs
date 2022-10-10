using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetPunchesByTypesHandler : IRequestHandler<GetPunchesByTypesRequest, GetPunchesByTypesResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetPunchesByTypesHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetPunchesByTypesResponse> Handle(GetPunchesByTypesRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPunchesByTypesQuery();
        var types = await _queryExecutor.Execute(query);
        var mappedTypes = _mapper.Map<List<Domain.Models.Types>>(types);
        var response = new GetPunchesByTypesResponse()
        {
            Data = mappedTypes 
        };
        return response;
    }
}
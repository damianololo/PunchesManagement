using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetPunchesByIdHandler : IRequestHandler<GetPunchesByIdRequest, GetPunchesByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetPunchesByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetPunchesByIdResponse> Handle(GetPunchesByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPunchesByIdQuery()
        {
            SearchId = request.SearchId
        };
        var punches = await _queryExecutor.Execute(query);
        var mappedPunches = _mapper.Map<Domain.Models.Punches>(punches);
        var response = new GetPunchesByIdResponse()
        { 
            Data = mappedPunches 
        };
        return response;
    }
}

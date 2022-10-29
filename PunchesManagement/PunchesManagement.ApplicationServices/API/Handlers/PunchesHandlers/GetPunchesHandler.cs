using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.Models;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
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
        var query = new GetPunchesQuery()
        {
            SearchPhrase = request.SearchPhrase,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };

        var punches = await _queryExecutor.Execute(query);

        if (punches is null)
        {
            return new GetPunchesResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedPunches = _mapper.Map<List<Domain.Models.Punches>>(punches);
        var totalItemsCount = query.TotalItemsCount;
        var result = new PagedResult<Punches>(mappedPunches, totalItemsCount, request.PageSize, request.PageNumber);

        var response = new GetPunchesResponse()
        {
            Data = result 
        };

        return response;
    }
}

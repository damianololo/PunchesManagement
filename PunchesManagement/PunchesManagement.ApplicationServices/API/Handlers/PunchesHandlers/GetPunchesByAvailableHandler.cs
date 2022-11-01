using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries.PunchesQuery;

namespace PunchesManagement.ApplicationServices.API.Handlers.PunchesHandlers;

public class GetPunchesByAvailableHandler : IRequestHandler<GetPunchesByAvailableRequest, GetPunchesByAvailableResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetPunchesByAvailableHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetPunchesByAvailableResponse> Handle(GetPunchesByAvailableRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPunchesByAvailableQuery()
        {
            Inspection = request.Inspection
        };
        var punches = await _queryExecutor.Execute(query);

        if (punches is null)
        {
            return new GetPunchesByAvailableResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedPunches = _mapper.Map<Domain.Models.Punches>(punches);
        var response = new GetPunchesByAvailableResponse()
        {
            Data = mappedPunches
        };
        return response;
    }
}

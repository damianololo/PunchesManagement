using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetPunchesByTypesIdHandler : IRequestHandler<GetPunchesByTypesIdRequest, GetPunchesByTypesIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetPunchesByTypesIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }


    public async Task<GetPunchesByTypesIdResponse> Handle(GetPunchesByTypesIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetPunchesByTypesIdQuery()
        {
            Id = request.TypesId
        };
        var types = await _queryExecutor.Execute(query);
        var mappedTypes = _mapper.Map<List<Domain.Models.Punches>>(types.Punches);
        var response = new GetPunchesByTypesIdResponse()
        {
            Data = mappedTypes
        };
        return response;
    }
}

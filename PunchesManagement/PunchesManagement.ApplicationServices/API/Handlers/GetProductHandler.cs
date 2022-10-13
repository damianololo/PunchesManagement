using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetProductHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        var query = new GetProductQuery();
        var product = await _queryExecutor.Execute(query);
        var mappedProduct = _mapper.Map<Domain.Models.Product>(product);
        var response = new GetProductResponse()
        {
            Data = mappedProduct 
        };
        return response;
    }
}

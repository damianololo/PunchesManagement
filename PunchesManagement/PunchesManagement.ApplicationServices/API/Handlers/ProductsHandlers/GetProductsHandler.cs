using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.Models;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries.ProductsQuery;

namespace PunchesManagement.ApplicationServices.API.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsRequest, GetProductsResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetProductsHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
    {
        var query = new GetProductsQuery()
        {
            SearchPhrase = request.SearchPhrase,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            SortBy = request.SortBy,
            SortDirection = request.SortDirection
        };

        var products = await _queryExecutor.Execute(query);

        if (products is null)
        {
            return new GetProductsResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedProducts = _mapper.Map<List<Domain.Models.Product>>(products);
        var totalItemsCount = query.TotalItemsCount;
        var result = new PagedResult<Product>(mappedProducts, totalItemsCount, request.PageSize, request.PageNumber);

        var response = new GetProductsResponse()
        {
            Data = result
        };

        return response;
    }
}

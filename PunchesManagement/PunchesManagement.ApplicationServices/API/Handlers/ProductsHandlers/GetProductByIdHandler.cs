using AutoMapper;
using MediatR;
using PunchesManagement.ApplicationServices.API.Domain;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;
using PunchesManagement.ApplicationServices.API.ErrorHandling;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.CQRS.Queries.ProductsQuery;

namespace PunchesManagement.ApplicationServices.API.Handlers.ProductsHandlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
{
    private readonly IMapper _mapper;
    private readonly IQueryExecutor _queryExecutor;

    public GetProductByIdHandler(IMapper mapper, IQueryExecutor queryExecutor)
    {
        _mapper = mapper;
        _queryExecutor = queryExecutor;
    }

    public async Task<GetProductByIdResponse> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery()
        {
            SearchId = request.SearchId,
        };
        var product = await _queryExecutor.Execute(query);

        if (product is null)
        {
            return new GetProductByIdResponse()
            {
                Error = new ErrorModel(ErrorType.NotFound)
            };
        }

        var mappedProduct = _mapper.Map<Domain.Models.Product>(product);
        var response = new GetProductByIdResponse()
        {
            Data = mappedProduct
        };
        return response;
    }
}

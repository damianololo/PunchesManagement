using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

public class GetProductsRequest : IRequest<GetProductsResponse>
{
    public string ?SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

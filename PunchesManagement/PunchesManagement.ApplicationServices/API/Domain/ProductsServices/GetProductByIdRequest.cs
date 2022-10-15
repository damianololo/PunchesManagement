using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
{
    public int SearchId { get; set; }
}

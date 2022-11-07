using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

public class GetProductByIdRequest : RequestBase, IRequest<GetProductByIdResponse>
{
    public int SearchId { get; set; }
}

using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

public class DeleteProductRequest : IRequest<DeleteProductResponse>
{
    public int DeleteId { get; set; }
}

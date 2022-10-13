using MediatR;
using Microsoft.EntityFrameworkCore;

namespace PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

public class AddProductRequest : IRequest<AddProductResponse>
{
    public string Name { get; set; }
    public string Series { get; set; }
    public string Description { get; set; }
    public DateTime ProductionTime { get; set; }

    public int TabletPressId { get; set; }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

public class AddProductRequest : RequestBase, IRequest<AddProductResponse>
{
    public string Name { get; set; }
    public string Series { get; set; }
    public string Description { get; set; }
    public decimal BatchSize { get; set; }
    //public DateTime ProductionTimeStart { get; set; }

    public int TabletPressId { get; set; }
}

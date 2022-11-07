using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

public class UpdateProductRequest : RequestBase, IRequest<UpdateProductResponse>
{
    public int UpdateId { get; set; }
    public string Name { get; set; }
    public string Series { get; set; }
    public string Description { get; set; }
    public int Output { get; set; }
    public decimal BatchSize { get; set; }
    public DateTime ProductionTimeStart { get; set; }
    public DateTime ProductionTimeStop { get; set; }
    public decimal RealWorkingTime { get; set; }

    public int TabletPressId { get; set; }
}

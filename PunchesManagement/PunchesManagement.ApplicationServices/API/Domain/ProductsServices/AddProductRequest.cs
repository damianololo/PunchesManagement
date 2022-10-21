using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

public class AddProductRequest : IRequest<AddProductResponse>
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    [MaxLength(50)]
    [Required]
    public string Series { get; set; }
    [MaxLength(1500)]
    public string Description { get; set; }
    [Precision(6, 2)]
    public decimal BatchSize { get; set; }
    public DateTime ProductionTimeStart { get; set; }

    public int TabletPressId { get; set; }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class UpdatePunchesRequest : IRequest<UpdatePunchesResponse>
{
    public int UpdateId { get; set; }
    [MaxLength(10)]
    [Required]
    public string Size { get; set; }
    [MaxLength(20)]
    [Required]
    public string Series { get; set; }
    [Precision(6, 2)]
    public decimal MachineHour { get; set; }
    public bool InInspection { get; set; }
    public int ManufacturerId { get; set; }
    public int TypesId { get; set; }
}

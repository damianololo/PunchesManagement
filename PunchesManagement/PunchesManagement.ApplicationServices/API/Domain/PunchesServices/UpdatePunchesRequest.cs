using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class UpdatePunchesRequest : RequestBase, IRequest<UpdatePunchesResponse>
{
    public int UpdateId { get; set; }
    public string Size { get; set; }
    public string Series { get; set; }
    public decimal MachineHour { get; set; }
    public bool InInspection { get; set; }
    public int ManufacturerId { get; set; }
    public int TypesId { get; set; }
}

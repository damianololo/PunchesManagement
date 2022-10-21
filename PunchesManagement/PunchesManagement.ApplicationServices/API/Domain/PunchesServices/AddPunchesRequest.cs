using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class AddPunchesRequest : IRequest<AddPunchesResponse>
{
    [MaxLength(10)]
    [Required]
    public string Size { get; set; }
    [MaxLength(20)]
    [Required]
    public string Series { get; set; }

    public int ManufacturerId { get; set; }

    public int TypesId { get; set; }
}

using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

public class UpdateTabletPressRequest : IRequest<UpdateTabletPressResponse>
{
    public int UpdateId { get; set; }
    [MaxLength(20)]
    [Required]
    public string Name { get; set; }
    [MaxLength(20)]
    public string Producer { get; set; }
    public int NumberOfStation { get; set; }
    public int TypesId { get; set; }
}

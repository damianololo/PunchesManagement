using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

public class AddTabletPressRequest : IRequest<AddTabletPressResponse>
{
    [MaxLength(20)]
    [Required]
    public string Name { get; set; }
    [MaxLength(20)]
    public string Producer { get; set; }
    public int NumberOfStation { get; set; }

    public int TypesId { get; set; }
}

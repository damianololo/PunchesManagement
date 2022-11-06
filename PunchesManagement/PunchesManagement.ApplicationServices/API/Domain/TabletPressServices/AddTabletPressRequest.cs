using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

public class AddTabletPressRequest : IRequest<AddTabletPressResponse>
{
    public string Name { get; set; }
    public string Producer { get; set; }
    public int NumberOfStation { get; set; }

    public int TypesId { get; set; }
}

using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

public class AddTabletPressRequest : RequestBase, IRequest<AddTabletPressResponse>
{
    public string Name { get; set; }
    public string Producer { get; set; }
    public int NumberOfStation { get; set; }

    public int TypesId { get; set; }
}

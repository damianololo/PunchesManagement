using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

public class GetTabletPressesRequest : RequestBase, IRequest<GetTabletPressesResponse>
{
    public string? SearchPhrase { get; set; }
}

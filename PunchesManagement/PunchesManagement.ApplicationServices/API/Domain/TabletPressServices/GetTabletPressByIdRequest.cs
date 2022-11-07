using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

public class GetTabletPressByIdRequest : RequestBase, IRequest<GetTabletPressByIdResponse>
{
    public int SearchId { get; set; }
}

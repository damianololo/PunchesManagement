using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

public class DeleteTabletPressRequest : RequestBase, IRequest<DeleteTabletPressResponse>
{
    public int DeleteId { get; set; }
}

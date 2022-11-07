using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class DeletePunchesRequest : RequestBase, IRequest<DeletePunchesResponse>
{
    public int DeleteId { get; set; }
}

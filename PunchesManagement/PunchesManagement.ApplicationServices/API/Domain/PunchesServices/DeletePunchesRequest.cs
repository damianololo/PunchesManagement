using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class DeletePunchesRequest : IRequest<DeletePunchesResponse>
{
    public int DeleteId { get; set; }
}

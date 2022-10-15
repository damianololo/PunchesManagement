using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class GetPunchesRequest : IRequest<GetPunchesResponse>
{
    public string ?SearchPhrase { get; set; }
}

using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class GetPunchesByAvailableRequest : IRequest<GetPunchesByAvailableResponse>
{
    public bool Inspection { get; set; }
}

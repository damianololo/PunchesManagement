using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class GetPunchesByIdRequest : IRequest<GetPunchesByIdResponse>
{
    public int SearchId { get; set; }
}

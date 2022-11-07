using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class GetPunchesByIdRequest : RequestBase, IRequest<GetPunchesByIdResponse>
{
    public int SearchId { get; set; }
}

using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class GetUserByIdRequest : RequestBase, IRequest<GetUserByIdResponse>
{
    public int SearchId { get; set; }
}

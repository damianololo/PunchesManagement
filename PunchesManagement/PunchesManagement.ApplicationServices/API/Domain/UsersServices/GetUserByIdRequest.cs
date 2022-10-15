using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
{
    public int SearchId { get; set; }
}

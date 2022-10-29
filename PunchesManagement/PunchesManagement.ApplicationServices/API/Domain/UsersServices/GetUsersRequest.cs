using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class GetUsersRequest : IRequest<GetUsersResponse>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

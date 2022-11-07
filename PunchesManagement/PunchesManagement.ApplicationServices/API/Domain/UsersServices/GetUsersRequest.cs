using MediatR;
using PunchesManagement.DataAccess.Enums;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class GetUsersRequest : RequestBase, IRequest<GetUsersResponse>
{
    public string? SearchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string ?SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}

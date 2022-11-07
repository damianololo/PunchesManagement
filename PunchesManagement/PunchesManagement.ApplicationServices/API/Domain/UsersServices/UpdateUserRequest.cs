using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class UpdateUserRequest : RequestBase, IRequest<UpdateUserResponse>
{
    public int UpdateId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public int UserRoleId { get; set; }
}

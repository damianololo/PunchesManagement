using MediatR;
using PunchesManagement.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.UsersServices;

public class AddUserRequest : IRequest<AddUserResponse>
{
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(50)]
    [Required]
    public string PasswordHash { get; set; }

    public int UserRoleId { get; set; }
}

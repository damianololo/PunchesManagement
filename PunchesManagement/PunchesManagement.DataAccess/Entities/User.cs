using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public class User : EntityBase
{
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(50)]
    [Required]
    public string UserName { get; set; }
    [Required]
    public string PasswordHash { get; set; }

    public UserRole UserRole { get; set; }
    public int UserRoleId { get; set; }
}

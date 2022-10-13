using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public class UserRole : EntityBase
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    public List<User> User { get; set; }
}

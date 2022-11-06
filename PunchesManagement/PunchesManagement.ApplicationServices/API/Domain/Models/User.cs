using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.Models;

public class User
{
    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string LastName { get; set; }
    [MaxLength(50)]
    [Required]
    public string Username { get; set; }
    public string UserRole { get; set; }
}

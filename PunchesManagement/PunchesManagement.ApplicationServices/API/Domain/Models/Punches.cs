using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.Models;

public class Punches
{
    public int Id { get; set; }
    [MaxLength(10)]
    [Required]
    public string Size { get; set; }
    [MaxLength(20)]
    [Required]
    public string Series { get; set; }
    public string Types { get; set; }
    public string Manufacturer { get; set; }
}

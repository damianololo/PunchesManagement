using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.Models;

public class TabletPress
{
    public int Id { get; set; }
    [MaxLength(20)]
    [Required]
    public string Name { get; set; }
    public int NumberOfStation { get; set; }

    public string Types { get; set; }
}

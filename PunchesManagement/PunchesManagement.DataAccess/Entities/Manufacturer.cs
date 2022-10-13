using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public class Manufacturer : EntityBase
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    public List<Punches> Punches { get; set; } = new List<Punches>();
}

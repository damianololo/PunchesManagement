using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public class Types : EntityBase
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }

    public List<Punches> Punches { get; set; } = new List<Punches>();

    public List<TabletPress> TabletPress { get; set; } = new List<TabletPress>();
}

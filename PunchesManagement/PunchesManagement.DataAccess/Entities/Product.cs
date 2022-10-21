using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public class Product : EntityBase
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    [MaxLength(20)]
    [Required]
    public string Series { get; set; }
    [MaxLength(1500)]
    public string Description { get; set; }
    public int Output { get; set; }
    [Precision(6, 2)]
    public decimal BatchSize { get; set; }
    public DateTime ProductionTimeStart { get; set; }
    public DateTime ProductionTimeStop { get; set; }
    [Precision(6, 2)]
    public decimal RealWorkingTime { get; set; }

    public TabletPress TabletPress { get; set; }
    public int TabletPressId { get; set; }
}

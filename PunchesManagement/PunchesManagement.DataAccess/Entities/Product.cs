using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public class Product : EntityBase
{
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    [MaxLength(50)]
    [Required]
    public string Series { get; set; }
    public int Output { get; set; }
    [Precision(6, 2)]
    public decimal BatchSize { get; set; }
    public int WorkingTime { get; set; }
    [MaxLength(1000)]
    public string Description { get; set; }
    public DateTime ProductionTime { get; set; }   //UsingDate stamps == ProductionTime products!!

    public TabletPress TabletPress { get; set; }
    public int TabletPressId { get; set; }
}

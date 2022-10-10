using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public class Punches : EntityBase
{
    [MaxLength(50)]
    [Required]
    public string Size { get; set; }
    public string Series { get; set; }
    [Precision(6, 2)]
    public decimal MachineHour { get; set; }
    public bool InInspection { get; set; }

    public List<TabletPress> TabletPress { get; set; }
    //public List<TabletPressPunches> TabletPressPunches { get; set; }

    public Manufacturer Manufacturer { get; set; }
    public int ManufacturerId { get; set; }

    public Types Types { get; set; }
    public int TypesId { get; set; }
}

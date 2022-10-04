using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public class Punches : EntityBase
{
    [MaxLength(50)]
    [Required]
    public string Size { get; set; }
    public string Series { get; set; }
    public DateTime UsingDate { get; set; }  //UsingDate stamps == ProductionTime products!!
    [Precision(6, 2)]
    public decimal MachineHour { get; set; }
    public bool InInspection { get; set; }

    public int TabletPressId { get; set; }
    public virtual TabletPress TabletPress { get; set; }
}

using Microsoft.EntityFrameworkCore;

namespace PunchesManagement.DataAccess.Entities;

public class Product : EntityBase
{
    public string Name { get; set; }
    public int Series { get; set; }
    public int Output { get; set; }
    [Precision(6, 2)]
    public decimal BatchSize { get; set; }
    public int WorkingTime { get; set; }
    public string Description { get; set; }
    public DateTime ProductionTime { get; set; }   //UsingDate stamps == ProductionTime products!!

    public TabletPress TabletPress { get; set; }
    public int TabletPressId { get; set; }
}

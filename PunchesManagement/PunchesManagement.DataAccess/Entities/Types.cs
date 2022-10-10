namespace PunchesManagement.DataAccess.Entities;

public class Types : EntityBase
{
    public string Name { get; set; }

    public List<Punches> Punches { get; set; } = new List<Punches>();

    public List<TabletPress> TabletPress { get; set; } = new List<TabletPress>();
}

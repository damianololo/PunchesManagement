namespace PunchesManagement.DataAccess.Entities;

public class Manufacturer : EntityBase
{
    public string Name { get; set; }

    public List<Punches> Punches { get; set; } = new List<Punches>();
}

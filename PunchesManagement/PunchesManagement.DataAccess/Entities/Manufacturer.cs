namespace PunchesManagement.DataAccess.Entities;

public class Manufacturer : EntityBase
{
    public string Name { get; set; }

    public virtual Punches Punches { get; set; }
}

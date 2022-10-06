namespace PunchesManagement.DataAccess.Entities;

public class Types : EntityBase
{
    public string Name { get; set; }

    public virtual Punches Punches { get; set; }
}

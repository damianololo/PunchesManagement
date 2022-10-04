namespace PunchesManagement.DataAccess.Entities;

public class TabletPress : EntityBase
{
    public string Name { get; set; }
    public string Producer { get; set; }
    public int NumberOfStation { get; set; }

    public virtual List<Punches> Punches { get; set; }

    public virtual List<Product> Products { get; set; }
}

namespace PunchesManagement.DataAccess.Entities;

public class TabletPress : EntityBase
{
    public string Name { get; set; }
    public string Producer { get; set; }
    public int NumberOfStation { get; set; }

    public Types Types { get; set; }
    public int TypesId { get; set; }

    public List<Punches> Punches { get; set; }
    //public List<TabletPressPunches> TabletPressPunches { get; set; }

    public List<Product> Products { get; set; }
}

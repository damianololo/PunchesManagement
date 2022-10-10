namespace PunchesManagement.ApplicationServices.API.Domain.Models;

public class Types
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Punches> Punches { get; set; }
}

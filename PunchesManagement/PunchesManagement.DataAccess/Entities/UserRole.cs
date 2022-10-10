namespace PunchesManagement.DataAccess.Entities;

public class UserRole : EntityBase
{
    public string Name { get; set; }

    public List<User> User { get; set; }
}

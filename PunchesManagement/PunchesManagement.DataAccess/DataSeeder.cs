using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess;

public class DataSeeder
{
    private readonly PunchesManagementContext _context;

    public DataSeeder(PunchesManagementContext context)
	{
        _context = context;

    }

    public void Seed()
    {
        if (_context.Database.CanConnect())
        {
            if (!_context.UserRoles.Any())
            {
                var userRoles = GetUserRoles();
                _context.UserRoles.AddRange(userRoles);
                _context.SaveChanges();
            }
        }
    }

    private IEnumerable<UserRole> GetUserRoles()
    {
        var roles = new List<UserRole>()
            {
                new UserRole()
                {
                    Name = "Operator"
                },
                new UserRole()
                {
                    Name = "Mistrz zmianowy"
                },
                new UserRole()
                {
                    Name = "Kierownik produkcji"
                },
                new UserRole()
                {
                    Name = "Admin"
                }
            };

        return roles;
    }
}

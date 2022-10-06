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

            if (!_context.Manufacturer.Any())
            {
                var manufacturers = GetManufacturers();
                _context.Manufacturer.AddRange(manufacturers);
                _context.SaveChanges();
            }

            if (!_context.Types.Any())
            {
                var types = GetTypes();
                _context.Types.AddRange(types);
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

    private IEnumerable<Manufacturer> GetManufacturers()
    {
        var manufacturers = new List<Manufacturer>()
            {
                new Manufacturer()
                {
                    Name = "Adamus"
                },
                new Manufacturer()
                {
                    Name = "Jato"
                },
                new Manufacturer()
                {
                    Name = "Manesty"
                }
            };

        return manufacturers;
    }

    private IEnumerable<Types> GetTypes()
    {
        var types = new List<Types>()
            {
                new Types()
                {
                    Name = "Euro B"
                },
                new Types()
                {
                    Name = "Euro D"
                }
            };

        return types;
    }
}

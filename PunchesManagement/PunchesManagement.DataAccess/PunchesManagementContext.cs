using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess;

public class PunchesManagementContext : DbContext
{
    public PunchesManagementContext(DbContextOptions<PunchesManagementContext> options)
        : base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<TabletPress> TabletPresses { get; set; }
    public DbSet<Punches> Punches { get; set; }
    public DbSet<Manufacturer> Manufacturer { get; set; }
    public DbSet<Types> Types { get; set; }
    public DbSet<Product> Products { get; set; }
}

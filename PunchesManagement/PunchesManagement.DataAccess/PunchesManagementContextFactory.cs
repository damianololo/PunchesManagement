using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PunchesManagement.DataAccess;

public class StampManagementContextFactory : IDesignTimeDbContextFactory<PunchesManagementContext>
{
    public PunchesManagementContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PunchesManagementContext>();
        optionsBuilder.UseSqlServer(
            "Data Source = ORZEŁKOWO\\SQLEXPRESS; Initial Catalog = PunchesManagementDB; Integrated Security = True");
        return new PunchesManagementContext(optionsBuilder.Options);
    }
}

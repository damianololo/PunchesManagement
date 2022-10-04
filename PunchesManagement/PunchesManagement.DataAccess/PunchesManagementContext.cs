using Microsoft.EntityFrameworkCore;

namespace PunchesManagement.DataAccess;

public class PunchesManagementContext : DbContext
{
    public PunchesManagementContext(DbContextOptions<PunchesManagementContext> options)
        : base(options)
    {

    }
}

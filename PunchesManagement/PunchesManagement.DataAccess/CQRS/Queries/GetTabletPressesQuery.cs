using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetTabletPressesQuery : QueryBase<List<TabletPress>>
{
    public override Task<List<TabletPress>> Execute(PunchesManagementContext context)
    {
        return context.TabletPresses.Include(x => x.Types).ToListAsync();
    }
}

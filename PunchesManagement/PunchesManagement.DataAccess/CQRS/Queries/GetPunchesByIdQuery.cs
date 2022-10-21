using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetPunchesByIdQuery : QueryBase<Punches>
{
    public int SearchId { get; set; }

    public override async Task<Punches> Execute(PunchesManagementContext context)
    {
        var punches = await context.Punches
            .Include(r => r.Types)
            .Include(r => r.Manufacturer)
            .FirstOrDefaultAsync(x => x.Id == SearchId);
        return punches;
    }
}

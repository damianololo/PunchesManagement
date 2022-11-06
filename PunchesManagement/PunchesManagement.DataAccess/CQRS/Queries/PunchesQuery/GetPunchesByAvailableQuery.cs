using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries.PunchesQuery;

public class GetPunchesByAvailableQuery : QueryBase<List<Punches>>
{
    public bool Inspection { get; set; }

    public override async Task<List<Punches>> Execute(PunchesManagementContext context)
    {
        var punches = await context.Punches
            .Include(r => r.Types)
            .Include(r => r.Manufacturer)
            .Where(r => r.InInspection.ToString() == Inspection.ToString())
            .ToListAsync();

        return punches;
    }
}

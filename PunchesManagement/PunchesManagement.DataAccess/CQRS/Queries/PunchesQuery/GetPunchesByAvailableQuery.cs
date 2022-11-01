using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

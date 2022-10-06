using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetPunchesQuery : QueryBase<List<Punches>>
{
    public override Task<List<Punches>> Execute(PunchesManagementContext context)
    {
        return context.Punches.ToListAsync();
    }
}

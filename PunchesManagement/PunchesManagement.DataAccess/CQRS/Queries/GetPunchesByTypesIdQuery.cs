using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries;

public class GetPunchesByTypesIdQuery : QueryBase<Types>
{
    public int Id { get; set; }

    public override async Task<Types> Execute(PunchesManagementContext context)
    {
        var types = await context.Types.Include(r => r.Punches).FirstOrDefaultAsync(x => x.Id == Id);
        return types;
    }
}

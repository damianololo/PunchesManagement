using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries.UsersQuery;

public class GetUserByIdQuery : QueryBase<User>
{
    public int SearchId { get; set; }

    public override async Task<User> Execute(PunchesManagementContext context)
    {
        var user = await context.Users.Include(x => x.UserRole).FirstOrDefaultAsync(x => x.Id == SearchId);
        return user;
    }
}

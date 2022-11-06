using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Queries.UsersQuery;

public class GetUserQuery : QueryBase<User>
{
    public string UserName { get; set; }

    public override async Task<User> Execute(PunchesManagementContext context)
    {
        var user = await context.Users
            .Include(x => x.UserRole)
            .FirstOrDefaultAsync(x => x.UserName == UserName);
        return user;
    }
}

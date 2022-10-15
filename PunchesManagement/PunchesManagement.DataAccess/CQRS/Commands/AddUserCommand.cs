using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class AddUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(PunchesManagementContext context)
    {
        await context.Users.AddAsync(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}

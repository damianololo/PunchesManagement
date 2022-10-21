using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class UpdateUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(PunchesManagementContext context)
    {
        context.ChangeTracker.Clear();
        context.Users.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}

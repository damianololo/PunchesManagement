using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class DeleteUserCommand : CommandBase<User, User>
{
    public override async Task<User> Execute(PunchesManagementContext context)
    {
        context.ChangeTracker.Clear();
        context.Users.RemoveRange(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}

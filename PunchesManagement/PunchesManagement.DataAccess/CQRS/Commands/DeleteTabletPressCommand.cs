using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class DeleteTabletPressCommand : CommandBase<TabletPress, TabletPress>
{
    public override async Task<TabletPress> Execute(PunchesManagementContext context)
    {
        context.ChangeTracker.Clear();
        context.TabletPresses.RemoveRange(Parameter);
        await context.SaveChangesAsync();
        return Parameter;
    }
}

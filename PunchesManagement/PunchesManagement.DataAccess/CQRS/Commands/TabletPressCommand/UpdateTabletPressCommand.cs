using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands.TabletPressCommand;

public class UpdateTabletPressCommand : CommandBase<TabletPress, TabletPress>
{
    public override async Task<TabletPress> Execute(PunchesManagementContext context)
    {
        context.ChangeTracker.Clear();
        context.TabletPresses.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}

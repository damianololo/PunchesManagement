using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class AddTabletPressCommand : CommandBase<TabletPress, TabletPress>
{
    public override async Task<TabletPress> Execute(PunchesManagementContext context)
    {
        await context.TabletPresses.AddAsync(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}

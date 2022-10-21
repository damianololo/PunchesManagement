using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class UpdatePunchesCommand : CommandBase<Punches, Punches>
{
    public override async Task<Punches> Execute(PunchesManagementContext context)
    {
        context.ChangeTracker.Clear();
        context.Punches.Update(Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}

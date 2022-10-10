using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.DataAccess.CQRS.Commands;

public class AddPunchesCommand : CommandBase<Punches, Punches>
{
    public override async Task<Punches> Execute(PunchesManagementContext context)
    {
        await context.Punches.AddAsync(this.Parameter);
        await context.SaveChangesAsync();
        return this.Parameter;
    }
}

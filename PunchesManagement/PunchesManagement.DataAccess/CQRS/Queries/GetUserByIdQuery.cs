using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchesManagement.DataAccess.CQRS.Queries
{
    public class GetUserByIdQuery : QueryBase<User>
    {
        public int SearchId { get; set; }

        public override async Task<User> Execute(PunchesManagementContext context)
        {
            var user = await context.Users.Include(x => x.UserRole).FirstOrDefaultAsync(x => x.Id == SearchId);
            return user;
        }
    }
}

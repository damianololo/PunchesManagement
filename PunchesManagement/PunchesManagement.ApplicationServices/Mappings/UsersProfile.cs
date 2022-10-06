using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain.Models;

namespace PunchesManagement.ApplicationServices.Mappings;

public class UsersProfile : Profile
{
	public UsersProfile()
	{
		CreateMap<DataAccess.Entities.User, User>()
			.ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
			.ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
			.ForMember(x => x.UserRole, y => y.MapFrom(z => z.UserRole));
    }
}

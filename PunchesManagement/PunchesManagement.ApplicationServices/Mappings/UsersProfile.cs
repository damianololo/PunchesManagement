using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain.Models;
using PunchesManagement.ApplicationServices.API.Domain.UsersServices;

namespace PunchesManagement.ApplicationServices.Mappings;

public class UsersProfile : Profile
{
	public UsersProfile()
	{
		CreateMap<DataAccess.Entities.User, User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
			.ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
			.ForMember(x => x.UserRole, y => y.MapFrom(z => z.UserRole.Name));

        CreateMap<AddUserRequest, DataAccess.Entities.User>()
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.PasswordHash))
            .ForMember(x => x.UserRoleId, y => y.MapFrom(z => z.UserRoleId));
    }
}
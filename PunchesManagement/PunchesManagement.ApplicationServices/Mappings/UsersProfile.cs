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
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
			.ForMember(x => x.Username, y => y.MapFrom(z => z.UserName))
            .ForMember(x => x.UserRole, y => y.MapFrom(z => z.UserRole.Name));

        CreateMap<AddUserRequest, DataAccess.Entities.User>()
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.Username))
            .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.Password))
            .ForMember(x => x.UserRoleId, y => y.MapFrom(z => z.UserRoleId));

        CreateMap<DeleteUserRequest, DataAccess.Entities.User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.DeleteId));

        CreateMap<UpdateUserRequest, DataAccess.Entities.User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.UpdateId))
            .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
            .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.Username))
            .ForMember(x => x.PasswordHash, y => y.MapFrom(z => z.PasswordHash))
            .ForMember(x => x.UserRoleId, y => y.MapFrom(z => z.UserRoleId));
    }
}
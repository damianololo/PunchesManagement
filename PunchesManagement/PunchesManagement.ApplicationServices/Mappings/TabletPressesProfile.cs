using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain.Models;

namespace PunchesManagement.ApplicationServices.Mappings;

public class TabletPressesProfile : Profile
{
	public TabletPressesProfile()
	{
        CreateMap<DataAccess.Entities.TabletPress, TabletPress>()
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.NumberOfStation, y => y.MapFrom(z => z.NumberOfStation));
    }
}

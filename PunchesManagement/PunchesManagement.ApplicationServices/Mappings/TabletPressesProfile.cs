using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain.Models;
using PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

namespace PunchesManagement.ApplicationServices.Mappings;

public class TabletPressesProfile : Profile
{
	public TabletPressesProfile()
	{
        CreateMap<DataAccess.Entities.TabletPress, TabletPress>()
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.NumberOfStation, y => y.MapFrom(z => z.NumberOfStation))
           .ForMember(x => x.Types, y => y.MapFrom(z => z.Types.Name));

        CreateMap<AddTabletPressRequest, DataAccess.Entities.TabletPress>()
           .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
           .ForMember(x => x.Producer, y => y.MapFrom(z => z.Producer))
           .ForMember(x => x.NumberOfStation, y => y.MapFrom(z => z.NumberOfStation))
           .ForMember(x => x.TypesId, y => y.MapFrom(z => z.TypesId));
    }
}

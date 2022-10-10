using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain;

namespace PunchesManagement.ApplicationServices.Mappings;

public class PunchesProfile : Profile
{
	public PunchesProfile()
	{
        CreateMap<DataAccess.Entities.Punches, API.Domain.Models.Punches>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.Types, y => y.MapFrom(z => z.Types.Name));

        CreateMap<AddPunchesRequest, DataAccess.Entities.Punches>()
            .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.ManufacturerId, y => y.MapFrom(z => z.ManufacturerId))
            .ForMember(x => x.TypesId, y => y.MapFrom(z => z.TypesId));
    }
}

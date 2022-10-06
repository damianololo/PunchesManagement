using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain.Models;

namespace PunchesManagement.ApplicationServices.Mappings;

public class PunchesProfile : Profile
{
	public PunchesProfile()
	{
        CreateMap<DataAccess.Entities.Punches, Punches>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series));
    }
}

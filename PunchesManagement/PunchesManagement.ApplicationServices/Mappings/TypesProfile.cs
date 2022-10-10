using AutoMapper;

namespace PunchesManagement.ApplicationServices.Mappings;

public class TypesProfile : Profile
{
    public TypesProfile()
    {
        CreateMap<DataAccess.Entities.Types, API.Domain.Models.Types>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Punches, y => y.MapFrom(z => z.Punches));
    }
}

using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

namespace PunchesManagement.ApplicationServices.Mappings;

public class PunchesProfile : Profile
{
	public PunchesProfile()
	{
        CreateMap<DataAccess.Entities.Punches, API.Domain.Models.Punches>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.Types, y => y.MapFrom(z => z.Types.Name))
            .ForMember(x => x.Manufacturer, y => y.MapFrom(z => z.Manufacturer.Name));

        CreateMap<AddPunchesRequest, DataAccess.Entities.Punches>()
            .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.ManufacturerId, y => y.MapFrom(z => z.ManufacturerId))
            .ForMember(x => x.TypesId, y => y.MapFrom(z => z.TypesId));

        CreateMap<DeletePunchesRequest, DataAccess.Entities.Punches>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.DeleteId));

        CreateMap<UpdatePunchesRequest, DataAccess.Entities.Punches>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.UpdateId))
            .ForMember(x => x.Size, y => y.MapFrom(z => z.Size))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.MachineHour, y => y.MapFrom(z => z.MachineHour))
            .ForMember(x => x.InInspection, y => y.MapFrom(z => z.InInspection));
    }
}

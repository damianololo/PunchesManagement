using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain.Models;
using PunchesManagement.ApplicationServices.API.Domain.ProductsServices;

namespace PunchesManagement.ApplicationServices.Mappings;

public class ProductsProfile : Profile
{
	public ProductsProfile()
	{
        CreateMap<DataAccess.Entities.Product, Product>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.BatchSize, y => y.MapFrom(z => z.BatchSize))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
            .ForMember(x => x.Output, y => y.MapFrom(z => z.Output))
            .ForMember(x => x.ProductionTimeStart, y => y.MapFrom(z => z.ProductionTimeStart))
            .ForMember(x => x.RealWorkingTime, y => y.MapFrom(z => z.RealWorkingTime))
            .ForMember(x => x.TabletPress, y => y.MapFrom(z => z.TabletPress.Name));

        CreateMap<AddProductRequest, DataAccess.Entities.Product>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.BatchSize, y => y.MapFrom(z => z.BatchSize))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
            //.ForMember(x => x.ProductionTimeStart, y => y.MapFrom(z => z.ProductionTimeStart))
            .ForMember(x => x.TabletPressId, y => y.MapFrom(z => z.TabletPressId));

        CreateMap<DeleteProductRequest, DataAccess.Entities.Product>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.DeleteId));

        CreateMap<UpdateProductRequest, DataAccess.Entities.Product>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.UpdateId))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
            .ForMember(x => x.Output, y => y.MapFrom(z => z.Output))
            .ForMember(x => x.BatchSize, y => y.MapFrom(z => z.BatchSize))
            .ForMember(x => x.ProductionTimeStart, y => y.MapFrom(z => z.ProductionTimeStart))
            .ForMember(x => x.ProductionTimeStop, y => y.MapFrom(z => z.ProductionTimeStop))
            .ForMember(x => x.RealWorkingTime, y => y.MapFrom(z => z.RealWorkingTime))
            .ForMember(x => x.TabletPressId, y => y.MapFrom(z => z.TabletPressId));
    }
}

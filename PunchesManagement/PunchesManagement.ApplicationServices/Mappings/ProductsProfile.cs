using AutoMapper;
using PunchesManagement.ApplicationServices.API.Domain.Models;

namespace PunchesManagement.ApplicationServices.Mappings;

public class ProductsProfile : Profile
{
	public ProductsProfile()
	{
        CreateMap<DataAccess.Entities.Product, Product>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Series, y => y.MapFrom(z => z.Series))
            .ForMember(x => x.BatchSize, y => y.MapFrom(z => z.BatchSize))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Description));

    }
}

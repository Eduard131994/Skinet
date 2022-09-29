using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(dest => dest.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(dest => dest.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(dest => dest.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
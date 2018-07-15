using AutoMapper;
using eShop.Data.Entities;
using eShop.DataContracts.Dtos;

namespace eShop
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                        .ForMember(d => d.OsIcon, opt => opt.MapFrom(src => src.Os.IconName));
        }
    }
}

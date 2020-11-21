using AutoMapper;
using DevBase.Entities.DTOs;
using DevBase.Entities.Tangible;

namespace DevBase.UI.AutoMapping
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}
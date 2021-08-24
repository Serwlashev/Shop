using AutoMapper;
using Services.DTO;
using Shop.Models;

namespace Shop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryViewModel, CategoryDTO>();
            CreateMap<CategoryDTO, CategoryViewModel>();

            CreateMap<ProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, ProductViewModel>();
        }
    }
}

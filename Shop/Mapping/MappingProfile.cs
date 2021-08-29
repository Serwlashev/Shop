using AutoMapper;
using Services.Abstract.DTO;
using Shop.Models;

namespace Shop.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryModel, CategoryDTO>();
            CreateMap<CategoryDTO, CategoryModel>();

            CreateMap<ProductModel, ProductDTO>();
            CreateMap<ProductDTO, ProductModel>();
        }
    }
}

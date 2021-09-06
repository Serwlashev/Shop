using Core.Application.DTO;
using AutoMapper;
using Presentation.Shop.Models;

namespace Presentation.Shop.Mapping
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

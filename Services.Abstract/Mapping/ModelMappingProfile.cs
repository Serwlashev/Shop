using AutoMapper;
using Domain.Entity;
using Services.Abstract.DTO;

namespace Services.Abstract.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
        }
    }
}

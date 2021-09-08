using Core.Application.DTO;
using AutoMapper;
using Core.Domain.Entity;
using Core.Application.Features.Queries.GetAllProduct;
using Core.Application.Features.Queries.GetByIdProduct;
using Core.Application.Features.Queries.GetByIdCategory;

namespace Core.Application.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();

            CreateMap<Product, ProductDTO>()
                .ReverseMap();

            CreateMap<ProductDTO, GetAllProductQueryResponse>();

            CreateMap<ProductDTO, GetByIdProductQueryResponse>();

            CreateMap<CategoryDTO, GetByIdCategoryQueryResponse>();

        }
    }
}

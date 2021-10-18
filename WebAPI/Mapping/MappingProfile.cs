using Core.Application.DTO;
using AutoMapper;
using WebAPI.Features.Queries.GetAllProduct;
using WebAPI.Features.Queries.GetByIdProduct;
using WebAPI.Features.Queries.GetByIdCategory;
using WebAPI.Features.Queries.GetAllCategory;
using WebAPI.Features.Queries.FindProducts;
using WebAPI.Features.Queries.GetByClientCart;

namespace WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, GetAllProductQueryResponse>();

            CreateMap<ProductDTO, GetByIdProductQueryResponse>();
            
            CreateMap<ProductDTO, FindProductsQueryResponse>();

            CreateMap<CategoryDTO, GetAllCategoryQueryResponse>();

            CreateMap<CategoryDTO, GetByIdCategoryQueryResponse>();

            CreateMap<CartItemDTO, GetByClientCartQueryResponse>();
        }
    }
}

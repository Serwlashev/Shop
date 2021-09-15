using Core.Application.DTO;
using AutoMapper;
using Core.Domain.Entity;
using Core.Application.Features.Queries.GetAllProduct;
using Core.Application.Features.Queries.GetByIdProduct;
using Core.Application.Features.Queries.GetByIdCategory;
using Core.Application.Features.Queries.GetAllCategory;
using System;
using System.Linq.Expressions;

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

            CreateMap<User, UserDTO>()
                .ReverseMap();

            //CreateMap<Expression<Func<UserDTO, bool>>, Expression<Func<User, bool>>>()
            //    .DisableCtorValidation();

            CreateMap<ProductDTO, GetAllProductQueryResponse>();

            CreateMap<ProductDTO, GetByIdProductQueryResponse>();

            CreateMap<CategoryDTO, GetAllCategoryQueryResponse>();

            CreateMap<CategoryDTO, GetByIdCategoryQueryResponse>();
        }
    }
}

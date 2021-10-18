using Core.Application.DTO;
using AutoMapper;
using Core.Domain.Entity;

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

            CreateMap<CartItem, CartItemDTO>()
                .ReverseMap();
        }
    }
}

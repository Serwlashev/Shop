using Core.Application.DTO;

namespace Core.Application.Interfaces
{
    public interface ICartService : IBaseService<long, CartItemDTO>
    {
    }
}

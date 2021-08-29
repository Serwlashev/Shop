using Services.Abstract.DTO;

namespace Services.Abstract.Interfaces
{
    public interface IProductService : IBaseService<long, ProductDTO>
    {
    }
}

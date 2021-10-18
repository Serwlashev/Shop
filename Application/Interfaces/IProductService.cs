using Core.Application.DTO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IProductService : IBaseService<long, ProductDTO>
    {
        Task<IEnumerable<ProductDTO>> FindProductsAsync(string searchText, CancellationToken token = default);
    }
}

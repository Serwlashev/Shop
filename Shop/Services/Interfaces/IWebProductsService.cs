using Presentation.Shop.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Shop.Services.Interfaces
{
    public interface IWebProductsService
    {
        Task<IEnumerable<ProductModel>> GetAllAsync(CancellationToken token = default);
        Task<ProductModel> GetAsync(long id, CancellationToken token = default);
        Task<IEnumerable<ProductModel>> FindProductsAsync(string searchText, CancellationToken token = default);
        Task<bool> UpdateAsync(ProductModel entity, CancellationToken token = default);
        Task<bool> CreateAsync(ProductModel entity, CancellationToken token = default);
        Task<bool> RemoveAsync(long id, CancellationToken token = default);
    }
}

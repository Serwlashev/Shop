using Presentation.Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Shop.Services.Interfaces
{
    public interface IWebProductsService
    {
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<ProductModel> GetAsync(long id);
        Task<IEnumerable<ProductModel>> FindProductsAsync(string searchText);
        Task<bool> UpdateAsync(ProductModel entity);
        Task<bool> CreateAsync(ProductModel entity);
        Task<bool> RemoveAsync(long id);
    }
}

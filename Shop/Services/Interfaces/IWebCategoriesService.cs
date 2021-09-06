using Presentation.Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Shop.Services.Interfaces
{
    public interface IWebCategoriesService
    {
        Task<IEnumerable<CategoryModel>> GetAllAsync();
        Task<CategoryModel> GetAsync(long id);
        Task<bool> UpdateAsync(CategoryModel entity);
        Task<bool> CreateAsync(CategoryModel entity);
        Task<bool> RemoveAsync(long id);
    }
}

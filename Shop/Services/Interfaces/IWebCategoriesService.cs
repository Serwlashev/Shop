using Presentation.Shop.Models.Categories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Shop.Services.Interfaces
{
    public interface IWebCategoriesService
    {
        Task<IEnumerable<CategoryModel>> GetAllAsync(CancellationToken token = default);
        Task<CategoryModel> GetAsync(long id, CancellationToken token = default);
        Task<bool> UpdateAsync(CategoryModel entity, CancellationToken token = default);
        Task<bool> CreateAsync(CategoryModel entity, CancellationToken token = default);
        Task<bool> RemoveAsync(long id, CancellationToken token = default);
    }
}

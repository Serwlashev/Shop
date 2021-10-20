using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Shop.Utils.Interfaces
{
    public interface IApiUtil
    {
        Task<string> LoginAsync(string url, string email, string password, CancellationToken token = default);
        Task<T> GetAsync<T>(string url, CancellationToken token = default);
        Task<bool> PostAsync<T>(string url, T entity, CancellationToken token = default);
        Task<bool> PutAsync<T>(string url, T entity, CancellationToken token = default);
        Task<bool> DeleteAsync(string url, CancellationToken token = default);
    }
}

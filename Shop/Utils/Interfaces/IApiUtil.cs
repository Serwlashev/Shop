using System.Threading.Tasks;

namespace Presentation.Shop.Utils.Interfaces
{
    public interface IApiUtil
    {
        Task<string> LoginAsync(string url, string email, string password);
        Task<T> GetAsync<T>(string url);
        Task<bool> PostAsync<T>(string url, T entity);
        Task<bool> PutAsync<T>(string url, T entity);
        Task<bool> DeleteAsync(string url);
    }
}

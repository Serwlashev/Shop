using System.Net.Http;
using System.Threading.Tasks;

namespace Presentation.Shop.Utils.Interfaces
{
    public interface IHttpUtil
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync<T>(string url, T data);
        Task<HttpResponseMessage> PutAsync<T>(string url, T data);
        Task<HttpResponseMessage> DeleteAsync(string url);
    }
}

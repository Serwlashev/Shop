using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Shop.Utils.Interfaces
{
    public interface IHttpUtil
    {
        Task<HttpResponseMessage> GetAsync(string url, CancellationToken token = default);
        Task<HttpResponseMessage> PostAsync<T>(string url, T data, CancellationToken token = default);
        Task<HttpResponseMessage> PutAsync<T>(string url, T data, CancellationToken token = default);
        Task<HttpResponseMessage> DeleteAsync(string url, CancellationToken token = default);
    }
}

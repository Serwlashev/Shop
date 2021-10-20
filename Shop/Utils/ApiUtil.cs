using Newtonsoft.Json;
using Presentation.Shop.Utils.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Presentation.Shop.Utils
{
    public class ApiUtil : IApiUtil
    {
        private readonly IHttpUtil _httpUtil;

        public ApiUtil(IHttpUtil httpUtil)
        {
            _httpUtil = httpUtil;
        }

        public async Task<bool> PostAsync<T>(string url, T entity, CancellationToken token = default)
        {
            var httpResponse = await _httpUtil.PostAsync(url, entity, token);

            if(httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(string url, CancellationToken token = default)
        {
            var httpResponse = await _httpUtil.DeleteAsync(url, token);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<T> GetAsync<T>(string url, CancellationToken token = default)
        {
            T responseModel = default;

            HttpResponseMessage httpResponse = default;

            httpResponse = await _httpUtil.GetAsync(url, token);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string stringResponse = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                responseModel = JsonConvert.DeserializeObject<T>(stringResponse);
            }

            return responseModel;
        }

        public Task<string> LoginAsync(string url, string email, string password, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PutAsync<T>(string url, T entity, CancellationToken token = default)
        {
            var httpResponse = await _httpUtil.PutAsync(url, entity, token);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}

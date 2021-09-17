using Newtonsoft.Json;
using Presentation.Shop.Utils.Interfaces;
using System;
using System.Net;
using System.Net.Http;
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

        public async Task<bool> PostAsync<T>(string url, T entity)
        {
            var httpResponse = await _httpUtil.PostAsync(url, entity);

            if(httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(string url)
        {
            var httpResponse = await _httpUtil.DeleteAsync(url);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            T responseModel = default;

            HttpResponseMessage httpResponse = default;

            httpResponse = await _httpUtil.GetAsync(url);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                string stringResponse = await httpResponse.Content.ReadAsStringAsync();

                responseModel = JsonConvert.DeserializeObject<T>(stringResponse);
            }

            return responseModel;
        }

        public Task<string> LoginAsync(string url, string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PutAsync<T>(string url, T entity)
        {
            var httpResponse = await _httpUtil.PutAsync(url, entity);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}

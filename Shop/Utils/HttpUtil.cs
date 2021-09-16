using Newtonsoft.Json;
using Presentation.Shop.Utils.Interfaces;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Shop.Utils
{
    public class HttpUtil : IHttpUtil
    {
        private readonly HttpClient _client;

        public HttpUtil()
        {
            _client = new HttpClient();
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, url);

            var responseMessage = await _client.SendAsync(requestMessage);

            return responseMessage;

        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            HttpResponseMessage httpResponse = await _client.SendAsync(requestMessage);

            return httpResponse;
        }

        public async Task<HttpResponseMessage> PostAsync<T>(string url, T postData)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8)
            };

            var responseMessage = await _client.SendAsync(requestMessage);

            return responseMessage;
        }
    }
}

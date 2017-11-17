using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Provisioning.HttpExtensions
{
    public static class HttpClientExtensions
    {
        private const string _defaultMediaType = "application/json";

        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string requestUri) where T : class, new()
        {
            var json = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string endpointUrlTemplate, params string[] endpointTokenValue) where T : class, new()
        {
            return await httpClient.GetAsync<T>(string.Format(endpointUrlTemplate, endpointTokenValue));
        }

        public static async Task<V> PostAsync<T, V>(this HttpClient httpClient, string requestUri, T contentBody) where T : class
        {
            var json = JsonConvert.SerializeObject(contentBody, Formatting.Indented);
            var resp = await httpClient.PostAsync(requestUri, new StringContent(json, Encoding.UTF8, _defaultMediaType));
            await EnsureSuccessStatusCode(resp);
            var respContent = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<V>(respContent);
        }

        public static async Task<V> PutAsync<T, V>(this HttpClient httpClient, string requestUri, T contentBody) where T : class
        {
            var json = JsonConvert.SerializeObject(contentBody);
            var resp = await httpClient.PutAsync(requestUri, new StringContent(json, Encoding.UTF8, _defaultMediaType));
            await EnsureSuccessStatusCode(resp);
            var respContent = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<V>(respContent);
        }

        private static async Task EnsureSuccessStatusCode(HttpResponseMessage resp)
        {
            if(!resp.IsSuccessStatusCode)
            {
                var respContent = await resp.Content.ReadAsStringAsync();
                throw new HttpClientException($"Response did not return a success status code: {resp.StatusCode}: {respContent}")
                {
                    ResponseStatusCode = resp.StatusCode,
                    ResponseContent = respContent
                };
            }
        }


    }
}

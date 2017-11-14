using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Provisioning.TeamCity.Client
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string requestUri) where T : class, new()
        {
            var json = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static async Task<T> GetAsync<T>(this HttpClient httpClient, string endpointUrlTemplate, params string[] endpointTokenValue) where T : class, new()
        {
            return await httpClient.GetAsync<T>(Endpoints.Resolve(endpointUrlTemplate, endpointTokenValue));
        }

        public static async Task<V> PostAsync<T, V>(this HttpClient httpClient, string requestUri, T contentBody) where T : class
        {
            var resp = await httpClient.PostAsync(requestUri, new StringContent(JsonConvert.SerializeObject(contentBody), Encoding.UTF8, SupportedMediaTypes.ApplicationJson));
            resp.EnsureSuccessStatusCode();
            var respContent = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<V>(respContent);
        }

        public static async Task<V> PutAsync<T, V>(this HttpClient httpClient, string requestUri, T contentBody) where T : class
        {
            var resp = await httpClient.PutAsync(requestUri, new StringContent(JsonConvert.SerializeObject(contentBody), Encoding.UTF8, SupportedMediaTypes.ApplicationJson));
            resp.EnsureSuccessStatusCode();
            var respContent = await resp.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<V>(respContent);
        }
    }
}

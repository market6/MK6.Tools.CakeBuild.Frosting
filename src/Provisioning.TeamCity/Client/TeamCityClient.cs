using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Provisioning.TeamCity.Client
{
    public class TeamCityClient : IDisposable
    {
        private bool _disposedValue = false;
        private readonly HttpClient _httpClient;

        public ProjectsClient Projects { get; }
        public BuildTypesClient BuildTypes { get; }

<<<<<<< HEAD
        public TeamCityClient(TeamCityClientOptions options) : this()
        {
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(options.Username, options.Password),
                PreAuthenticate = true
            };

            _httpClient = new HttpClient(handler) { BaseAddress =  options.ServerUri };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(options.DefaultAcceptHeaderValue));
            _httpClient.DefaultRequestHeaders.Add("Origin", options.ServerUri.AbsoluteUri);
=======
        public TeamCityClient(Uri serverUri, string username, string password, string defaultAcceptHeaderValue = "application/json") : this()
        {
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(username, password),
                PreAuthenticate = true
            };

            _httpClient = new HttpClient(handler) { BaseAddress =  serverUri };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(defaultAcceptHeaderValue));
            _httpClient.DefaultRequestHeaders.Add("Origin", serverUri.AbsoluteUri);
>>>>>>> master
            Projects = new ProjectsClient(_httpClient);
            BuildTypes = new BuildTypesClient(_httpClient);
        }

        public TeamCityClient()
        {
            Newtonsoft.Json.JsonConvert.DefaultSettings = () => new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
            };
        }

        public TeamCityClient(HttpClient httpClient) : this()
        {
            _httpClient = httpClient;
            Projects = new ProjectsClient(_httpClient);
            BuildTypes = new BuildTypesClient(_httpClient);
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
        
    }
}

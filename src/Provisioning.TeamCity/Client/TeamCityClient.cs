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

        public TeamCityClient(Uri serverUri, string username, string password, string defaultAcceptHeaderValue = "application/json")
        {
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(username, password),
                //UseDefaultCredentials = true,
                PreAuthenticate = true
            };

            _httpClient = new HttpClient(handler) { BaseAddress =  serverUri };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(defaultAcceptHeaderValue));
            Projects = new ProjectsClient(_httpClient);
            BuildTypes = new BuildTypesClient(_httpClient);
        }

        public TeamCityClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Projects = new ProjectsClient(_httpClient);
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

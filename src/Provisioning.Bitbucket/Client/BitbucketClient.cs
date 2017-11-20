using Provisioning.Bitbucket.Client.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Provisioning.HttpExtensions;
using System;

namespace Provisioning.Bitbucket.Client
{
    public class BitbucketClient : IDisposable
    {
        private readonly HttpClient _httpClient;

        public BitbucketClient(BitbucketClientOptions options)
        {
            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(options.Username, options.Password),
                PreAuthenticate = true
            };

            _httpClient = new HttpClient(handler) { BaseAddress = options.ServerUri };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(options.DefaultAcceptHeaderValue));
            _httpClient.DefaultRequestHeaders.Add("Origin", options.ServerUri.AbsoluteUri);
        }

        public BitbucketClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Repository> CreateRepositoryAsync(string username, string repoSlug, Repository repository)
        {
            return await _httpClient.PutAsync<Repository, Repository>($"/2.0/repositories/{username}/{repoSlug}", repository);
        }

        public Repository CreateRepository(string username, string repoSlug, Repository repository)
        {
            return CreateRepositoryAsync(username, repoSlug, repository).Result;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}

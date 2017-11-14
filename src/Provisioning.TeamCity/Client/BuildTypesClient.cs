using Provisioning.TeamCity.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Provisioning.TeamCity.Client
{
    public class BuildTypesClient
    {
        private readonly HttpClient _httpClient;

        public BuildTypesClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BuildTypes> ByProjectLocatorAsync(string projectLocator)
        {
            return await _httpClient.GetAsync<BuildTypes>(Endpoints.BuildType.ByProjectLocator, projectLocator);
        }

        public async Task<BuildType> ByIdAsync(string buildTypeId)
        {
            return await _httpClient.GetAsync<BuildType>(Endpoints.BuildType.ById, buildTypeId);
        }
    }
}

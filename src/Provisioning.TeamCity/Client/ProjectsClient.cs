using Provisioning.TeamCity.Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Provisioning.TeamCity.Client
{
    public class ProjectsClient
    {
        private readonly HttpClient _httpClient;

        public ProjectsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Project> ByIdAsync(string projectLocatorId)
        {
            return await _httpClient.GetAsync<Project>(Endpoints.Project.ById, projectLocatorId);
        }

        public async Task<Project> ByNameAsync(string projectLocatorName)
        {
            return await _httpClient.GetAsync<Project>(Endpoints.Project.ByName, projectLocatorName);
        }

        public async Task<Project> CreateAsync(NewProject newProject)
        {
            return await _httpClient.PostAsync<NewProject, Project>(Endpoints.Project.Create, newProject);
        }

        public async Task<Parameter> SetParameterAsync(string projectName, string parameterName, string parameterValue)
        {
            return await _httpClient.PutAsync<Parameter, Parameter>(Endpoints.Resolve(Endpoints.Project.Parameters.ByName, projectName, parameterName), new Parameter { Value = parameterValue });
        }
        
    }   
}

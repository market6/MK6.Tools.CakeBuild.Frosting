using MK6.Tools.CakeBuild.Frosting;
using MK6.Tools.CakeBuild.Frosting.Utilities;
using Project = Provisioning.TeamCity.Client.Models.Project;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Provisioning.TeamCity.Client;
using Provisioning.TeamCity.Client.Models;
using Cake.Core.Annotations;
using Cake.Core;

namespace Provisioning.TeamCity
{
    public static class TeamCityExtensions
    {
        [CakeMethodAlias]
        public static async Task<Project> TeamCityProjectGetAsync(this ICakeContext context, TeamCityProjectLocatorType projectLocatorType, string projectLocatorValue, TeamCityClientOptions options)
        {
            using (var tcc = new TeamCityClient(options))
            {
                switch (projectLocatorType)
                {
                    case TeamCityProjectLocatorType.Id:
                        return await tcc.Projects.ByIdAsync(projectLocatorValue);
                    case TeamCityProjectLocatorType.Name:
                        return await tcc.Projects.ByNameAsync(projectLocatorValue);
                    default:
                        return await tcc.Projects.ByLocatorAsync(projectLocatorValue);
                }
            }
        }

        [CakeMethodAlias]
        public static Project TeamCityProjectGet(this ICakeContext context, TeamCityProjectLocatorType projectLocatorType, string projectLocatorValue, TeamCityClientOptions options)
        {
            return TeamCityProjectGetAsync(context, projectLocatorType, projectLocatorValue, options).Result;
        }

        [CakeMethodAlias]
        public static async Task<Project> TeamCityProjectCreateAsync(this ICakeContext context, NewProject newProject, TeamCityClientOptions options)
        {
            using (var tcc = new TeamCityClient(options))
            {
                return await tcc.Projects.CreateAsync(newProject);
            }
        }

        [CakeMethodAlias]
        public static Project TeamCityProjectCreate(this ICakeContext context, NewProject newProject, TeamCityClientOptions options)
        {
            return TeamCityProjectCreateAsync(context, newProject, options).Result;
        }

    }

    public enum TeamCityProjectLocatorType
    {
        Id,
        Name,
        Raw
    }
}

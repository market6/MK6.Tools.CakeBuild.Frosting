using MK6.Tools.CakeBuild.Frosting;
using MK6.Tools.CakeBuild.Frosting.Utilities;
using Project = Provisioning.TeamCity.Client.Models.Project;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Provisioning.TeamCity.Client;

namespace Provisioning.TeamCity
{
    public static class TeamCityExtensions
    {
        public static async Task<Project> TeamCityProjectGet(this Context context, TeamCityProjectLocatorType projectLocatorType, string projectLocatorValue, TeamCityClientOptions options)
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
    }

    public enum TeamCityProjectLocatorType
    {
        Id,
        Name,
        Raw
    }
}

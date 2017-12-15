using Cake.Frosting;
using MK6.Tools.CakeBuild.Frosting;
using Provisioning.Core;
using Provisioning.TeamCity.Client;
using Provisioning.TeamCity.Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provisioning.TeamCity.Tasks
{
    public class CreateProject : FrostingTask<ProvisioningContext>
    {
        public override void Run(ProvisioningContext context)
        {
            var options = new TeamCityClientOptions
            {
                Username = "***",
                Password = "***",
                ServerUri = new Uri("http://build.mk6.local")
            };

            //var p = context.TeamCityProjectGet(TeamCityProjectLocatorType.Id, "CakeProvision", options);
            var p = context.TeamCityProjectCreate(new NewProject { Id = "SampleProject2", Name = "SampleProject2", ParentProject = new NewProjectParent { Locator = "id:CakeProvision" } }, options);

        }
    }
}

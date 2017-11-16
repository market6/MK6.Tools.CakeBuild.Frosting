using Cake.Frosting;
using MK6.Tools.CakeBuild.Frosting;
using Provisioning.TeamCity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Provisioning.TeamCity.Tasks
{
    public class CreateProject : FrostingTask<Context>
    {
        public override void Run(Context context)
        {
            Console.WriteLine("Create the teamcity project here");
            context.Log.Write(Cake.Core.Diagnostics.Verbosity.Normal, Cake.Core.Diagnostics.LogLevel.Information, "Create the teamcity project here");
        }
    }
}

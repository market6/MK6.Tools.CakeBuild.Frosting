using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.NuGet.Push;
using Cake.Common.Tools.NuGet;
using Cake.Common.Tools.NuGet.Push;
using Cake.Core;
using Cake.Frosting;

namespace MK6.Tools.CakeBuild.Frosting.Tasks
{
    [TaskName("NugetPush")]
    [Dependency(typeof(Package))]
    public sealed class NugetPush : FrostingTask<Context>
    {
        public override void Run(Context context)
        {
            var nugetSettings = new DotNetCoreNuGetPushSettings
            {
                ApiKey = context.NugetDefaultPushSourceApiKey,
                Source = context.NugetDefaultPushSourceUrl
            };

            if (string.IsNullOrEmpty(nugetSettings.ApiKey))
                throw new CakeException("NugetDefaultPushSourceApiKey was not set!");

            context.DotNetCoreNuGetPush(".\\artifacts\\*.nupkg", nugetSettings);
        }


    }

}
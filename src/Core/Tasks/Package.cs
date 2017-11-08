using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Pack;
using Cake.Core;
using Cake.Frosting;
using System.Linq;

namespace MK6.Tools.CakeBuild.Frosting.Tasks
{
    [TaskName("Package")]
    [Dependency(typeof(Build))]
    public class Package : FrostingTask<Context>
    {
        public override void Run(Context context)
        {
            foreach (var project in context.Projects)
            {
                context.DotNetCorePack(project.ProjectPath.FullPath, new DotNetCorePackSettings()
                {
                    Configuration = context.Configuration,
                    NoBuild = true,
                    OutputDirectory = context.Artifacts,
                    IncludeSource = true,
                    IncludeSymbols = true,
                    ArgumentCustomization = args => args.Append("/p:Version={0}", context.BuildVersion.Version.NuGetVersionV2)
                });
            }

        }
    } 
}
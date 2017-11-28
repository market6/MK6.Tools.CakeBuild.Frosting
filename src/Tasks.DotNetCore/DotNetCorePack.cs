using Cake.Common.Diagnostics;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Pack;
using Cake.Core;
using Cake.Frosting;
using System.Linq;

namespace MK6.Tools.CakeBuild.Frosting.Tasks
{
    [Dependency(typeof(DotNetCoreBuild))]
    public class DotNetCorePack : FrostingTask<DotNetCoreContext>
    {
        public override void Run(DotNetCoreContext context)
        {
            foreach (var project in context.Projects.Where(x => x.ProjectParserResult.IsNetCore && !string.IsNullOrWhiteSpace(x.ProjectParserResult.NetCore.PackageId)))
            {
                context.Information("Packaging project {0} with version: {1}",project.ProjectParserResult.AssemblyName, context.BuildVersion.Version.FullSemVer);

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
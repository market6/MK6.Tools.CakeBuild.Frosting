using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Build;
using Cake.Core;

namespace MK6.Tools.CakeBuild.Frosting.Tasks
{
    [TaskName("Build")]
    [Dependency(typeof(Restore))]
    public sealed class Build : FrostingTask<Context>
    {

        public override void Run(Context context)
        {
            context.Validate(ValidateOptions.Default, true);
            context.DotNetCoreBuild(context.SolutionFilePath.FullPath, new DotNetCoreBuildSettings
            {
                Configuration = context.Configuration,
                ArgumentCustomization = args => args.Append("/p:Version={0}", context.BuildVersion.Version.FullSemVer)
            });
        }
    } 
}
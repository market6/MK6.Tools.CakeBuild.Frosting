using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.Common.Tools.DotNetCore;
using Cake.Common.Tools.DotNetCore.Clean;
using Cake.Common.IO;

namespace MK6.Tools.CakeBuild.Frosting.Tasks
{
    [TaskName("Clean")]
    public sealed class Clean : FrostingTask<Context>
    {
        public override void Run(Context context)
        {
            context.Validate(ValidateOptions.Default, true);
            context.Information("Executing dotnet clean on solution...");
            context.DotNetCoreClean(context.SolutionFilePath.FullPath, new DotNetCoreCleanSettings
            {
                Configuration = context.Configuration,
            });

            foreach (var dir in context.DirectoriesToClean)
            {
                context.Information("Cleaning directory: {0}", dir.FullPath);
                context.CleanDirectory(dir);
            }
        }
    } 
}
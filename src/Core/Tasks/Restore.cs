using Cake.Frosting;
using Cake.Common.Tools.DotNetCore;

namespace MK6.Tools.CakeBuild.Frosting.Tasks
{
    [TaskName("Restore")]
    [Dependency(typeof(Clean))]
    public sealed class Restore : FrostingTask<Context>
    {
        public override void Run(Context context)
        {
            context.DotNetCoreRestore(context.SolutionFilePath.FullPath);
        }
    } 
}

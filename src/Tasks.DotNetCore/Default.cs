using Cake.Frosting;

namespace MK6.Tools.CakeBuild.Frosting.Tasks
{
    [Dependency(typeof(DotNetCoreBuild))]
    public sealed class Default : FrostingTask<DotNetCoreContext>
    {
    } 
}
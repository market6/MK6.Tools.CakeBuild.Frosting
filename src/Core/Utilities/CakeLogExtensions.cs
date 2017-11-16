using Cake.Core.Diagnostics;

namespace MK6.Tools.CakeBuild.Frosting.Core.Utilities
{
    public static class CakeLogExtensions
    {
        public static void WriteInfo(this ICakeLog log, params object[] args)
        {
            log.Write(Verbosity.Normal, LogLevel.Information, "Create the teamcity project here", args);

        }
    }
}

using Cake.Common.Diagnostics;
using Cake.Common.Tools.GitVersion;
using Cake.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MK6.Tools.CakeBuild.Frosting.Utilities
{
    public class BuildVersion
    {
        public GitVersion Version { get; set; }

        public BuildVersion(GitVersion version)
        {
            Version = version;
        }

        public BuildVersion() : this(new GitVersion())
        {
        }

        public static BuildVersion Calculate(Context context)
        {
            context.Information("Calculating semantic version...");

            if (!context.IsLocalBuild)
            {
                // Run to set the version properties inside the CI server
                context.GitVersion(new GitVersionSettings { OutputType = GitVersionOutput.BuildServer });
            }

            // Run in interactive mode to get the properties for the rest of the script
            var assertedversions = context.GitVersion(new GitVersionSettings { OutputType = GitVersionOutput.Json }); //GitVersionRunner.Run(context, GitVersionOutput.Json);

            if (string.IsNullOrWhiteSpace(assertedversions.MajorMinorPatch))
            {
                throw new CakeException("Could not calculate version of build.");
            }

            return new BuildVersion(assertedversions);
        }


    } 
}

using Cake.Common;
using Cake.Common.Diagnostics;
using Cake.Core;
using Cake.Frosting;
using System.Linq;
using Cake.Incubator;
using Cake.Common.Solution;
using Cake.Common.Build;
using Cake.Core.IO;
using MK6.Tools.CakeBuild.Frosting.Utilities;

namespace MK6.Tools.CakeBuild.Frosting
{
    public sealed class Lifetime : FrostingLifetime<Context>
    {
        public override void Setup(Context context)
        {
            GitVersionTool.Install(context);

            context.Target = context.Argument("target", "Default");
            context.Configuration = context.Argument("configuration", "Release");
            context.SolutionRoot = context.FileSystem.GetDirectory(".").Path.MakeAbsolute(context.Environment);
            context.BuildVersion = BuildVersion.Calculate(context);
            context.Artifacts = context.Argument("artifacts", "./artifacts");
            context.NugetDefaultPushSourceUrl = GetEnvOrArg(context, "nugetDefaultPushSourceUrl", "NUGET_DEFAULT_PUSH_SOURCE_URL");
            context.NugetDefaultPushSourceApiKey = GetEnvOrArg(context, "NUGET_DEFAULT_PUSH_SOURCE_URL_API_KEY", "nugetDefaultPushSourceApiKey");

            var slnPath = context.Globber.Match("*.sln", x => true).SingleOrDefault(x => !x.FullPath.EndsWith("Build.sln", System.StringComparison.OrdinalIgnoreCase));
            if (slnPath == null)
                throw new CakeException("No solution file found in root!");

            context.SolutionFilePath = slnPath.FullPath;
            context.Information("Using solution: {0}", context.SolutionFilePath.FullPath);

            var slnResult = context.ParseSolution(context.SolutionFilePath);
            context.Projects = slnResult.Projects.Select(x => new Project(x.Path, context.ParseProject(x.Path, context.Configuration))).ToList().AsReadOnly();

            // Build system information.
            var buildSystem = context.BuildSystem();
            context.IsLocalBuild = buildSystem.IsLocalBuild;

            context.DirectoriesToClean = new DirectoryPath[] { context.Artifacts };
        }
        private static string GetEnvOrArg(Context context, string environmentVariable, string argumentName)
        {
            var arg = context.EnvironmentVariable(environmentVariable);
            if (string.IsNullOrWhiteSpace(arg))
            {
                arg = context.Argument<string>(argumentName, null);
            }
            return arg;
        }
    } 
}
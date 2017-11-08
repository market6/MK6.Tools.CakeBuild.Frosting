using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;
using Cake.Incubator;
using MK6.Tools.CakeBuild.Frosting.Utilities;
using System.Collections.Generic;

namespace MK6.Tools.CakeBuild.Frosting
{
    public class Context : FrostingContext
    {
        public BuildVersion BuildVersion { get; set; }
        public FilePath SolutionFilePath { get; set; }
        public DirectoryPath SolutionRoot { get; set; }
        public DirectoryPath Artifacts { get; set; }
        public string Configuration { get; set; }
        public string Target { get; set; }
        public IReadOnlyCollection<Project> Projects { get; set; }
        public bool IsLocalBuild { get; set; }
        public IReadOnlyCollection<DirectoryPath> DirectoriesToClean { get; set; }
        public string NugetDefaultPushSourceUrl { get; set; }
        public string NugetDefaultPushSourceApiKey { get; set; }

        public Context(ICakeContext context) : base(context)
        {

        }
    } 
}
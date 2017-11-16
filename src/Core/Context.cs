using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;
using Cake.Incubator;
using MK6.Tools.CakeBuild.Frosting.Utilities;
using System;
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

        public ValidateResult Validate(ValidateOptions options = null, bool throwException = true)
        {
            options = options ?? ValidateOptions.Default;

            AggregateException exception = null;

            if (options.SolutonFileMustExistInRoot && (!FileSystem.Exist(SolutionFilePath) || SolutionFilePath.IsSolution()))
                exception = new AggregateException("Validate failed. Check InnerExceptions for details", new CakeException("A valid solution file must exist in the working directory!"));

            if (exception != null && throwException)
                throw exception;

            return new ValidateResult(exception == null, exception);
        }
    }
}
﻿using Cake.Frosting;
using Cake.Common.Tools.DotNetCore;

namespace MK6.Tools.CakeBuild.Frosting.Tasks
{
    [Dependency(typeof(DotNetCoreClean))]
    public sealed class DotNetCoreRestore : FrostingTask<DotNetCoreContext>
    {
        public override void Run(DotNetCoreContext context)
        {
            context.Validate(ValidateOptions.Default, true);
            context.DotNetCoreRestore(context.SolutionFilePath.FullPath);
        }
    } 
}

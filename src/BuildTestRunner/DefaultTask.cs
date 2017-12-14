using Cake.Frosting;
using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using MK6.Tools.CakeBuild.Frosting;
using Cake.Common.Diagnostics;

namespace BuildTestRunner
{
    [TaskName("Default")]
    public sealed class DefaultTask : FrostingTask<MyContext>
    {
        public override void Run(MyContext context)
        {
            context.Information("CustomProperty={0}", context.CustomProperty);
        }

    }
}

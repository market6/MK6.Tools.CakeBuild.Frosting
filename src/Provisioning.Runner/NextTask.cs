using Cake.Common.Diagnostics;
using Cake.Frosting;
using Cake.Incubator;
using Provisioning.Core;

namespace Provisioning.Runner
{
    [TaskName("Next")]
    [Dependency(typeof(DefaultTask))]
    public class NextTask : FrostingTask<ProvisioningContext>
    {
        public override void Run(ProvisioningContext context)
        {
            context.Information("DefaultTaskOutputs: {0}", (string)context.TaskOutputs.DefaultTask.Message);
            context.Information(context.ScmRepositoryOptions.Dump());
        }
    }
}

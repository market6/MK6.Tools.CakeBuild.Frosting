using Cake.Frosting;
using Provisioning.Bitbucket.Tasks;
using Provisioning.Core;

namespace Provisioning.Runner
{
    [TaskName("Default")]
    public class DefaultTask : FrostingTask<ProvisioningContext>
    {
        public override void Run(ProvisioningContext context)
        {
        }
    }
}

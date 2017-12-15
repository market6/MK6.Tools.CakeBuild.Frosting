using Cake.Frosting;
using Provisioning.Core;
using Cake.Git;
using System.IO;

namespace Provisioning.LocalGit.Tasks
{
    public sealed class LocalGitInit : FrostingTask<ProvisioningContext>
    {
        public override void Run(ProvisioningContext context)
        {
            var cloneUrl = context.GitLocalOptions.CloenUrl;
            if (!Directory.Exists(context.GitLocalOptions.WorkingDirectory.FullPath))
                Directory.CreateDirectory(context.GitLocalOptions.WorkingDirectory.FullPath);

            var cloneDir = context.GitClone(cloneUrl, context.GitLocalOptions.WorkingDirectory, context.GitLocalOptions.CloneCredentials.UserName, context.GitLocalOptions.CloneCredentials.Password);
        }
    }

    public sealed class LocalGitFinalize : FrostingTask<ProvisioningContext>
    {
        public override void Run(ProvisioningContext context)
        {
            context.GitAddAll(context.GitLocalOptions.WorkingDirectory.FullPath);
            context.GitCommit(context.GitLocalOptions.WorkingDirectory, GetType().Assembly.FullName, "", "initial commit by provisioner");
            context.GitPush(context.GitLocalOptions.WorkingDirectory, context.GitLocalOptions.CloneCredentials.UserName, context.GitLocalOptions.CloneCredentials.Password);
        }
    }

}

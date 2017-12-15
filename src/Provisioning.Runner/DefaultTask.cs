using Cake.Frosting;
using Provisioning.Bitbucket.Tasks;
using Provisioning.Core;
using Provisioning.LocalGit.Tasks;
using Provisioning.ProjectGen.DotNetCore.Tasks;

namespace Provisioning.Runner
{
    [TaskName("Default")]
    [Dependency(typeof(BitbucketCreateRepo))] //Creates the remote repo
    [Dependency(typeof(LocalGitInit))] //Clones new remote repo
    [Dependency(typeof(ProjectGenDotNetNew))] //Generates .net core project using "dotnet new"
    [Dependency(typeof(LocalGitFinalize))] //Adds new files, commits and pushes to remote repo
    //Additional dependencies go here. TC project/build setup, octopus project setup
    public class DefaultTask : FrostingTask<ProvisioningContext>
    {
        public override void Run(ProvisioningContext context)
        {
        }
    }
}

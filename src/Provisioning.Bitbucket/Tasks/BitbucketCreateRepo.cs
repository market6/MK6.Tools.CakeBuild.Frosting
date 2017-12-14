using Cake.Common.Diagnostics;
using Cake.Frosting;
using Provisioning.Bitbucket.Client;
using Provisioning.Core;

namespace Provisioning.Bitbucket.Tasks
{
    public class BitbucketCreateRepo : FrostingTask<ProvisioningContext>
    {
        public override void Run(ProvisioningContext context)
        {
            context.Information("Creating repo: {0}/{1}", context.ScmRepositoryOptions.OwnerUsername, context.ScmRepositoryOptions.Name);
            var bco = new BitbucketClientOptions { ServerUri = context.ScmRepositoryOptions.ApiBaseAddress, Username = context.ScmRepositoryOptions.HttpBasicCredentials.UserName, Password = context.ScmRepositoryOptions.HttpBasicCredentials.Password };
            var repo = context.BitbucketCreateRepository(bco, context.ScmRepositoryOptions.OwnerUsername, context.ScmRepositoryOptions.Name, context.ScmRepositoryOptions.ScmType, context.ScmRepositoryOptions.IsPrivate);
            context.Information("Succeesfully created repo: {0}", repo.Name);

            dynamic outputs = new DynamicPropertyBag();
            outputs.NewRepository = repo;
            outputs.CloneUrl = $"git@bitbucket.org:{context.ScmRepositoryOptions.OwnerUsername}/{context.ScmRepositoryOptions.Name}.git"; //building the clone url here manually for now...it may exist in the reposnse when creating the repo;
            context.AddTaskOutput<BitbucketCreateRepo>(outputs);
        }
    }
}
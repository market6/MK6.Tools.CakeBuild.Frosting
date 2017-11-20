using Cake.Frosting;
using MK6.Tools.CakeBuild.Frosting;
using Provisioning.Bitbucket.Client;

namespace Provisioning.Bitbucket.Tasks
{
    public class BitbucketCreateRepo : FrostingTask<Context>
    {
        public override void Run(Context context)
        {
            const string ownerUsername = "joshschlesinger";
            const string repoSlug = "jstestrepo";
            const string scm = "git";
            const bool isPrivate = true;

            context.Log.Write(Cake.Core.Diagnostics.Verbosity.Normal, Cake.Core.Diagnostics.LogLevel.Information, "Creating repo: {0}/{1}", ownerUsername, repoSlug);
            var bco = new BitbucketClientOptions { ServerUri = new System.Uri("https://api.bitbucket.org"), Username = "***", Password = "***" };
            var repo = context.BitbucketCreateRepository(bco, ownerUsername, repoSlug, scm, isPrivate);
            context.Log.Write(Cake.Core.Diagnostics.Verbosity.Normal, Cake.Core.Diagnostics.LogLevel.Information, "Succeesfully created repo: {0}", repo.Name);
        }
    }
}
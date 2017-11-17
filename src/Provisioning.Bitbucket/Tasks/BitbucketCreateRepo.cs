using Cake.Frosting;
using MK6.Tools.CakeBuild.Frosting;
using Provisioning.Bitbucket.Client;

namespace Provisioning.Bitbucket.Tasks
{
    public class BitbucketCreateRepo : FrostingTask<Context>
    {
        public override void Run(Context context)
        {
            var bco = new BitbucketClientOptions { ServerUri = new System.Uri("https://api.bitbucket.org"), Username = "***", Password = "***" };
            var bc = new BitbucketClient(bco);

            var repo = bc.CreateRepository("joshschlesinger", "jstestrepo", new Client.Models.Repository { Scm = "git", IsPrivate = true });
        }
    }
}
using System;

namespace Provisioning.Bitbucket.Client
{
    public class BitbucketClientOptions
    {
        public Uri ServerUri { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string DefaultAcceptHeaderValue { get; set; }

        public BitbucketClientOptions()
        {
            DefaultAcceptHeaderValue = "application/json";
        }
    }
}

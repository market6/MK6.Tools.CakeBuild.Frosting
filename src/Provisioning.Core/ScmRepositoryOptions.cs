using System;
using System.Net;

namespace Provisioning.Core
{
    public class ScmRepositoryOptions
    {
        public string ScmType { get; set; }
        public string OwnerUsername { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public NetworkCredential HttpBasicCredentials { get; set; }
        public string AccessToken { get; set; }
        public Uri ApiBaseAddress { get; set; }

        public ScmRepositoryOptions()
        {
            ScmType = "git";
            IsPrivate = true;
        }
    }
}

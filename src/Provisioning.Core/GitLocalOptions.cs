using System.Net;
using Cake.Core.IO;

namespace Provisioning.Core
{
    public class GitLocalOptions
    {
        public string CloenUrl { get; set; }
        public NetworkCredential CloneCredentials { get; set; }
        /// <summary>
        /// The directory the remote repo will get cloned into
        /// </summary>
        public DirectoryPath WorkingDirectory { get; set; }
    }
}

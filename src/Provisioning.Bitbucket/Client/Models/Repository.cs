
using Newtonsoft.Json;

namespace Provisioning.Bitbucket.Client.Models
{
    public class Repository
    {
        [JsonProperty("has_wiki")]
        public bool HasWiki { get; set; }
        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }
        public string Scm { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

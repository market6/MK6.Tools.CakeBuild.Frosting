
using System.Collections.Generic;

namespace Provisioning.TeamCity.Client.Models
{
    public class ProjectFeatures
    {
        public long Count { get; set; }
        public string Href { get; set; }
        public IReadOnlyCollection<ProjectFeature> ProjectFeature { get; set; }
    }
}

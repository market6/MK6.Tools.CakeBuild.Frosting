
using System.Collections.Generic;

namespace Provisioning.TeamCity.Client.Models
{
    public class BuildTypes
    {
        public IReadOnlyCollection<BuildType> BuildType { get; set; }
        public long Count { get; set; }
    }
}

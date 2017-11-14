
using System.Collections.Generic;

namespace Provisioning.TeamCity.Client.Models
{
    public class Projects
    {
        public long Count { get; set; }
        public IReadOnlyCollection<Project> Project { get; set; }
    }
}

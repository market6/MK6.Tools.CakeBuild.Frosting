
using System.Collections.Generic;

namespace Provisioning.TeamCity.Client.Models
{
    public class Properties
    {
        public long Count { get; set; }
        public string Href { get; set; }
        public IReadOnlyCollection<Property> Property { get; set; }
    }
}

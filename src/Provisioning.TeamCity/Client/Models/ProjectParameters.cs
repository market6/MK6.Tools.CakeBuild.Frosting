
using System.Collections.Generic;

namespace Provisioning.TeamCity.Client.Models
{
    public class Parameters
    {
        public long Count { get; set; }
        public string Href { get; set; }
        public IReadOnlyCollection<Parameter> Property { get; set; }
    }
}

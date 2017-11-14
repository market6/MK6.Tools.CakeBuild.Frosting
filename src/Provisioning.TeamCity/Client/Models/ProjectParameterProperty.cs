
namespace Provisioning.TeamCity.Client.Models
{
    public class Parameter
    {
        public bool Inherited { get; set; }
        public string Name { get; set; }
        public PropertyType Type { get; set; }
        public string Value { get; set; }
    }
}

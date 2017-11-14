
namespace Provisioning.TeamCity.Client.Models
{
    public class NewProject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public NewProjectParent ParentProject { get; set; }
    }

    public class NewProjectParent
    {
        public string Locator { get; set; }
    }
}

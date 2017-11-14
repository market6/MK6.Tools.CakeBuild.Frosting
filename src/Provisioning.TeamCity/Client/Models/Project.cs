
namespace Provisioning.TeamCity.Client.Models
{
    public class Project
    {
        public BuildTypes BuildTypes { get; set; }
        public string Description { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Parameters Parameters { get; set; }
        public ParentProject ParentProject { get; set; }
        public string ParentProjectId { get; set; }
        public ProjectFeatures ProjectFeatures { get; set; }
        public Projects Projects { get; set; }
        public ReadOnlyUI ReadOnlyUI { get; set; }
        public Templates Templates { get; set; }
        public VcsRoots VcsRoots { get; set; }
        public string WebUrl { get; set; }
    }
}

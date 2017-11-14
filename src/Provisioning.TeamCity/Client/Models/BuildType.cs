
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Provisioning.TeamCity.Client.Models
{
    public class BuildType
    {
        [JsonProperty("agent-requirements")]
        public AgentRequirements AgentRequirements { get; set; }
        [JsonProperty("artifact-dependecies")]
        public AgentRequirements ArtifactDependencies { get; set; }
        public Builds Builds { get; set; }
        public Builds CompatibleAgents { get; set; }
        public AgentRequirements Features { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public Builds Investigations { get; set; }
        public string Name { get; set; }
        public Parameters Parameters { get; set; }
        public Project Project { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public Properties Settings { get; set; }
        public AgentRequirements SnapshotDependencies { get; set; }
        public Steps Steps { get; set; }
        public Triggers Triggers { get; set; }
        [JsonProperty("vcs-root-entries")]
        public VcsRootEntries VcsRootEntries { get; set; }
        public string WebUrl { get; set; }
    }

    public class VcsRootEntries
    {
        public long Count { get; set; }
        [JsonProperty("vcs-root-entry")]
        public IReadOnlyCollection<VcsRootEntry> VcsRootEntry { get; set; }
    }

    public class VcsRootEntry
    {
        public string CheckoutRules { get; set; }
        public string Id { get; set; }
        public VcsRoot VcsRoot { get; set; }
    }

    public class VcsRoot
    {
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Triggers
    {
        public long Count { get; set; }
        public Step[] Trigger { get; set; }
    }

    public class Steps
    {
        public long Count { get; set; }
        public Step[] Step { get; set; }
    }

    public class Step
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Properties Properties { get; set; }
        public string Type { get; set; }
    }

    public class Builds
    {
        public string Href { get; set; }
    }

    public class AgentRequirements
    {
        public long Count { get; set; }
    }
}

namespace Provisioning.Core
{
    public class ProjectGenOptions
    {
        /// <summary>
        /// Name of the installed template to use
        /// </summary>
        public string TemplateName { get; set; }
        /// <summary>
        /// The path to use to install a custom template from.
        /// </summary>
        /// <remarks>For DotNetCore this can be a filesystem path or nuget id. For a specific version of a nuget id add the suffix "::#.#.#"</remarks>
        public string InstallTemplatePath { get; set; }
        /// <summary>
        /// Root folder to use to generate project output
        /// </summary>
        public string OutputBasePath { get; set; }
        /// <summary>
        /// The name of the new project to create. This will also be the folder name.
        /// </summary>
        public string ProjectName { get; set; }

    }
}

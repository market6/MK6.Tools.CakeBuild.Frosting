using MK6.Tools.CakeBuild.Frosting;
using System;
using Cake.Core;
using System.Net;
using System.Dynamic;
using System.Collections.Generic;
using Cake.Frosting;

namespace Provisioning.Core
{
    public class ProvisioningContext : DynamicContext
    {
        public ScmRepositoryOptions ScmRepositoryOptions { get; set; }
        public ProjectGenOptions ProjectGenOptions { get; set; }
        public dynamic TaskOutputs { get; set; }
        public ProvisioningContext(ICakeContext context) : base(context)
        {
            TaskOutputs = new TaskOutputs();
        }

        public void AddTaskOutput<T>(dynamic output) where T : FrostingTask<ProvisioningContext>
        {
            TaskOutputs.AddTaskOutput<T>(output);
        }
    }

    public class DynamicPropertyBag : DynamicObject
    {
        public IDictionary<string, object> RawProperties { get; set; }

        public DynamicPropertyBag()
        {
            RawProperties = new Dictionary<string, object>();
        }
        
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!RawProperties.TryGetValue(binder.Name, out result))
                result =  null;

            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (RawProperties.ContainsKey(binder.Name))
                RawProperties[binder.Name] = value;
            else
                RawProperties.Add(binder.Name, value);

            return true;
        }
    }

    public class TaskOutputs : DynamicPropertyBag
    {
        public void AddTaskOutput<TTaskType>(dynamic output) where TTaskType : FrostingTask<ProvisioningContext>
        {
            RawProperties.Add(typeof(TTaskType).Name, output);
        }
    }

    public class ScmRepositoryOptions
    {
        public string ScmType { get; set; }
        public string OwnerUsername { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        public NetworkCredential HttpBasicCredentials { get; set; }
        public string AccessToken { get; set; }
        public Uri ApiBaseAddress { get; set; }

        public ScmRepositoryOptions()
        {
            ScmType = "git";
            IsPrivate = true;
        }
    }

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

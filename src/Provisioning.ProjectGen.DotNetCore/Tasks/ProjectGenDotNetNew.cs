using Cake.Frosting;
using Provisioning.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Provisioning.ProjectGen.DotNetCore.Tools.DotNetCore.New;
using Cake.Core;
using System.Linq;
using System.IO;

namespace Provisioning.ProjectGen.DotNetCore.Tasks
{
    public class ProjectGenDotNetNew : FrostingTask<ProvisioningContext>
    {
        public override void Run(ProvisioningContext context)
        {
            //TODO: Refactor validations to utility class
            # region VALIDATIONS
            if (context.ProjectGenOptions == null)
                throw new CakeException($"Context property {nameof(context.ProjectGenOptions)} was not initialized");

            var exceptions = new List<Exception>();

            if (string.IsNullOrWhiteSpace(context.ProjectGenOptions.TemplateName))
                exceptions.Add(new CakeException($"Context property {nameof(context.ProjectGenOptions)}.{nameof(context.ProjectGenOptions.TemplateName)} was not set and is required"));
            if (string.IsNullOrWhiteSpace(context.ProjectGenOptions.OutputBasePath))
                exceptions.Add(new CakeException($"Context property {nameof(context.ProjectGenOptions)}.{nameof(context.ProjectGenOptions.OutputBasePath)} was not set and is required"));
            if (string.IsNullOrWhiteSpace(context.ProjectGenOptions.ProjectName))
                exceptions.Add(new CakeException($"Context property {nameof(context.ProjectGenOptions)}.{nameof(context.ProjectGenOptions.ProjectName)} was not set and is required"));

            if (exceptions.Any())
                throw new AggregateException("One or more required context properties were missing. See inner exceptions for details", exceptions);
            #endregion

            //If using a custom template, install it here
            if (!string.IsNullOrWhiteSpace(context.ProjectGenOptions.InstallTemplatePath))
                context.DotNetNewInstallTemplate(context.ProjectGenOptions.InstallTemplatePath);

            //Run dotnet new to generate the project
            context.DotNetNewGenerate(context.ProjectGenOptions.TemplateName, new DotNetNewSettings
            {
                Output = Path.Combine(context.ProjectGenOptions.OutputBasePath, context.ProjectGenOptions.ProjectName) //Build the output path using the base path and project name
            });
        }
    }
}

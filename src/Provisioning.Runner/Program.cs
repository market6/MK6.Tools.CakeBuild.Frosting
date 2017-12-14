using Cake.Common;
using Cake.Frosting;
using MK6.Tools.CakeBuild.Frosting;
using Provisioning.Bitbucket.Tasks;
using Provisioning.Core;
using Provisioning.ProjectGen.DotNetCore.Tasks;
using Provisioning.TeamCity.Tasks;
using System;

namespace Provisioning.Runner
{
    public class Program : IFrostingStartup
    {
        public static int Main(string[] args)
        {
            // Create the host.
            var host = new CakeHostBuilder()
                .WithArguments(args)
                .UseStartup<Program>()
                .Build();

            // Run the host.
            return host.Run();
        }

        public void Configure(ICakeServices services)
        {
            ConfigureLifetime();
            //services.UseAssembly(typeof(DynamicContext).Assembly);
            //services.UseAssembly(typeof(BitbucketCreateRepo).Assembly);
            //services.UseAssembly(typeof(BitbucketCreateRepo).Assembly);
            services.UseAssembly(typeof(ProjectGenDotNetNew).Assembly);
            services.UseContext<ProvisioningContext>();
            services.UseLifetime<ProvisioningLifetime>();
            services.UseWorkingDirectory("..");
        }

        private void ConfigureLifetime()
        {
            ProvisioningLifetime.RegisterAdditionalSetup(ctx => {
                ctx.ScmRepositoryOptions = new ScmRepositoryOptions
                {
                    Name                    = ctx.Argument("scm-name", string.Empty),
                    Description             = ctx.Argument("scm-description", string.Empty),
                    IsPrivate               = ctx.Argument("scm-is-private", true),
                    OwnerUsername           = ctx.Argument("scm-owner-username", string.Empty),
                    HttpBasicCredentials    = new System.Net.NetworkCredential(ctx.Argument("scm-username", string.Empty), ctx.Argument("scm-password", string.Empty)),
                    ApiBaseAddress          = new Uri(ctx.Argument("scm-api-base-address", "https://api.bitbucket.org"))
                    
                };

                ctx.ProjectGenOptions = new ProjectGenOptions
                {
                    TemplateName    = ctx.Argument("gen-template-name", string.Empty),
                    OutputBasePath  = ctx.Argument("gen-output-base-path", string.Empty),
                    ProjectName     = ctx.Argument("gen-project-name", string.Empty),
                };
            });
        }
    }
}

using Cake.Frosting;
using MK6.Tools.CakeBuild.Frosting;
using Provisioning.Bitbucket.Tasks;
using Provisioning.TeamCity.Tasks;
using System;

namespace Privisioning.TeamCity.DemoBuild
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
            services.UseAssembly(typeof(Context).Assembly);
            services.UseAssembly(typeof(BitbucketCreateRepo).Assembly);
            services.UseContext<Context>();
            services.UseLifetime<Lifetime>();
            services.UseWorkingDirectory("..");
        }
    }
}

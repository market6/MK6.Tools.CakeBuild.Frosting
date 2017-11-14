using Cake.Frosting;
using MK6.Tools.CakeBuild.Frosting;
using System;

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
        services.UseContext<Context>();
        services.UseLifetime<Lifetime>();
        services.UseWorkingDirectory("..");
    }
}

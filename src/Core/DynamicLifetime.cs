using Cake.Common;
using Cake.Common.Build;
using Cake.Frosting;
using System;
using Cake.Core;

namespace MK6.Tools.CakeBuild.Frosting.Core
{
    public class DynamicLifetime : FrostingLifetime<DynamicContext>
    {
        private static object _lock = new object();
        private static Action<DynamicContext> _setupAction = null;
        private static Action<DynamicContext> _teardownAction = null;

        public static void RegisterAdditionalSetup(Action<DynamicContext> setupAction)
        {
            lock(_lock)
                _setupAction = setupAction;
        }

        public static void RegisterAdditionalTeardown(Action<DynamicContext> teardownAction)
        {
            lock (_lock)
                _teardownAction = teardownAction;
        }

        public override void Setup(DynamicContext context)
        {
            context.Target = context.Argument("target", "Default");
            var buildSystem = context.BuildSystem();
            context.Properties.IsLocalBuild = buildSystem.IsLocalBuild;

            lock(_lock)
                _setupAction?.Invoke(context);
        }

        public override void Teardown(DynamicContext context, ITeardownContext info)
        {
            lock (_lock)
                _teardownAction?.Invoke(context);
        }
        private static string GetEnvOrArg(DotNetCoreContext context, string environmentVariable, string argumentName)
        {
            var arg = context.EnvironmentVariable(environmentVariable);
            if (string.IsNullOrWhiteSpace(arg))
            {
                arg = context.Argument<string>(argumentName, null);
            }
            return arg;
        }
    }
}

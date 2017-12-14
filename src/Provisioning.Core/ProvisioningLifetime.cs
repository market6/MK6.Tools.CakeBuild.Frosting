using MK6.Tools.CakeBuild.Frosting;
using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;

namespace Provisioning.Core
{
    public class ProvisioningLifetime : DynamicLifetime
    {
        public static void RegisterAdditionalSetup(Action<ProvisioningContext> setupAction)
        {
            DynamicLifetime.RegisterAdditionalSetup(ctx => setupAction((ProvisioningContext)ctx));
        }

        public static void RegisterAdditionalTeardown(Action<ProvisioningContext> teardownAction)
        {
            DynamicLifetime.RegisterAdditionalTeardown(ctx => teardownAction((ProvisioningContext)ctx));
        }
    }
}

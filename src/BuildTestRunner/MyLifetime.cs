using Cake.Common.Diagnostics;
using Cake.Core;
using MK6.Tools.CakeBuild.Frosting;

namespace BuildTestRunner
{
    public class MyLifetime : DynamicLifetime
    {
        public MyLifetime()
        {

        }

        public override void Setup(DynamicContext context)
        {
            base.Setup(context);

            var myContext = context as MyContext;
            if (myContext == null)
                throw new CakeException("myContext was null!");

            myContext.Information("Setting MyContext properties!");
            myContext.CustomProperty = "CustomProperty set in MyLifetime";
        }
    }
}

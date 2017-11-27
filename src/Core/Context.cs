using Cake.Core;
using Cake.Core.IO;
using Cake.Frosting;
using Cake.Incubator;
using MK6.Tools.CakeBuild.Frosting.Utilities;
using System;
using System.Collections.Generic;

namespace MK6.Tools.CakeBuild.Frosting
{
    [Obsolete("Use the class DotNetCoreContext")]
    public class Context : DotNetCoreContext
    {

        public Context(ICakeContext context) : base(context)
        {
          
        }

        
    }
}
using MK6.Tools.CakeBuild.Frosting;
using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;

namespace BuildTestRunner
{
    public sealed class MyContext : DynamicContext
    {
        public string CustomProperty
        {
            get { return Properties.CustomProperty; }
            set { Properties.CustomProperty = value; }
        }

        public MyContext(ICakeContext context) : base(context)
        {

        }
    }
}

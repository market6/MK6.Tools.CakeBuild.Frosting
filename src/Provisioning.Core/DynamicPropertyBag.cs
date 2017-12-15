using System.Dynamic;
using System.Collections.Generic;

namespace Provisioning.Core
{
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
}

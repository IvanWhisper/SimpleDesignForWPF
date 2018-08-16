using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCenter.DefAttribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class InterceptorCallHandlerAttribute:Attribute
    {
        public int Timeout { get; set; }
        public InterceptorCallHandlerAttribute()
        {
            Timeout = 60;
        }
    }
}

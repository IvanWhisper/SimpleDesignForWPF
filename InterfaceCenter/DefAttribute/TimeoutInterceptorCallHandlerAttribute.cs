using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCenter.DefAttribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class TimeoutInterceptorCallHandlerAttribute:Attribute
    {
        public Guid ObjID { get; set; }
        public int Timeout { get; set; } = 5;
        public TimeoutInterceptorCallHandlerAttribute()
        {
            ObjID = Guid.NewGuid();
        }
    }
}

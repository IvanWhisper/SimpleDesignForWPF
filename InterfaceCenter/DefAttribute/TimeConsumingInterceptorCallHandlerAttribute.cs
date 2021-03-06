﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceCenter.DefAttribute
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class TimeConsumingInterceptorCallHandlerAttribute:Attribute
    {
        public Guid ObjID { get; set; }
        public TimeConsumingInterceptorCallHandlerAttribute()
        {
            ObjID = Guid.NewGuid();
        }
    }
}

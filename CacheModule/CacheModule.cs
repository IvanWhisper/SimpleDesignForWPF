using Autofac;
using CacheModule.Cache;
using InterfaceCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheModule
{
    public class CacheModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new TestCache())
                //builder.Register(c => new ConsoleLogger())
                //be a service
                .As<ICache>()
                //be a SingleInstance
                .SingleInstance();
        }
    }
}

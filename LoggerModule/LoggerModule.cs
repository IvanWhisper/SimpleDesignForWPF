using Autofac;
using InterfaceCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerModule
{
    public class LoggerModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new TextLogger())
            //builder.Register(c => new ConsoleLogger())
                //be a service
                .As<ILogger>()
                //be a SingleInstance
                .SingleInstance();
        }
    }
}

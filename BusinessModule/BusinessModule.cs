using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessModule.Business;
using InterfaceCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModule
{
    public class BusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Work>()
                //builder.Register(c => new ConsoleLogger())
                //be a service
                .As<IWork>()
                //.InterceptedBy(typeof(IAuthInterceptor))
                .EnableInterfaceInterceptors();
                //be a SingleInstance
        }
    }
}

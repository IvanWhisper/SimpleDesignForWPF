using Autofac;
using InterfaceCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPModule
{
    public class AOPModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthInterceptor>()
                //builder.Register(c => new ConsoleLogger())
                //be a service
                .As<IAuthInterceptor>();
        }
    }
}

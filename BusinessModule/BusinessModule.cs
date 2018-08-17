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
                .As<IWork>()
                //开启拦截
                .EnableInterfaceInterceptors();
        }
    }
}

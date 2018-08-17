using AOPModule.Interceptor;
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
                .As<IAuthInterceptor>();
            builder.RegisterType<TimeoutInterceptor>()
                .As<ITimeoutInterceptor>();
            builder.RegisterType<TimeconsumingInterceptor>()
                .As<ITimeconsumingInterceptor>();
        }
    }
}

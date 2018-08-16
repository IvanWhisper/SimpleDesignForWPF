using Autofac.Extras.DynamicProxy;
using InterfaceCenter;
using InterfaceCenter.DefAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModule.Business
{
    [Intercept(typeof(IAuthInterceptor))]
    public class Work : IWork
    {
        private ILogger _log;
        public Work(ILogger log)
        {
            _log = log;
        }

        [InterceptorCallHandler]
        public void DoSomething(string token)
        {
            _log.Info("Working working working!");
        }

        public void DoMorething(string token)
        {
            _log.Info("More Working More working More working!");
        }
    }
}

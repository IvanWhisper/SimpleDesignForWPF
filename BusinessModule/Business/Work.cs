using Autofac.Extras.DynamicProxy;
using InterfaceCenter;
using InterfaceCenter.DefAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessModule.Business
{
    [Intercept(typeof(IAuthInterceptor))]
    [Intercept(typeof(ITimeoutInterceptor))]
    [Intercept(typeof(ITimeconsumingInterceptor))]
    public class Work : IWork
    {
        private ILogger _log;
        private ICache _cache;
        private static string token;
        public Work(ILogger log,ICache cache)
        {
            _log = log;
            _cache = cache;
            token = _cache.Token;
        }

        [AuthInterceptorCallHandler]
        [TimeConsumingInterceptorCallHandlerAttribute]
        public void DoSomething(string Token,string param)
        {
            _log.Info("Working working working!");
        }
        [AuthInterceptorCallHandler]
        [TimeoutInterceptorCallHandler(Timeout =3)]
        [TimeConsumingInterceptorCallHandlerAttribute]
        public void DoMorething(string Token,string param)
        {
            Thread.Sleep(10000);
            _log.Info("More Working More working More working!");
        }
    }
}

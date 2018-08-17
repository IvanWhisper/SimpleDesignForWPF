using InterfaceCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using System.Reflection;
using InterfaceCenter.DefAttribute;
using System.Diagnostics;

namespace AOPModule.Interceptor
{
    public class TimeconsumingInterceptor : ITimeconsumingInterceptor
    {
        private ILogger _log;
        public TimeconsumingInterceptor(ILogger log)
        {
            this._log = log;
        }
        public void Intercept(IInvocation invocation)
        {
            if (invocation == null)
                return;
            MethodInfo methodInfo = invocation.MethodInvocationTarget;
            if (methodInfo == null)
            {
                methodInfo = invocation.Method;
            }
            TimeConsumingInterceptorCallHandlerAttribute authInterceptor = methodInfo.GetCustomAttributes<TimeConsumingInterceptorCallHandlerAttribute>(true).FirstOrDefault();
            if (authInterceptor != null)
            {
                _log.Info($"Method:[{invocation.Method.Name}] Param[{string.Join(",", invocation.Arguments.Select(a => a ?? "").ToString())}]");
                //adminToken
                Stopwatch sw = new Stopwatch();
                sw.Start();
                invocation.Proceed();
                sw.Stop();
                _log.Info($"Method be Proceed Consuming is {sw.ElapsedMilliseconds} ms");
                sw = null;
            }
            else
            {
                invocation.Proceed();
            }

        }
    }
}

using Castle.DynamicProxy;
using InterfaceCenter;
using InterfaceCenter.DefAttribute;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOPModule
{
    public class TimeoutInterceptor : ITimeoutInterceptor
    {
        private ILogger _log;
        public TimeoutInterceptor(ILogger log)
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
            TimeoutInterceptorCallHandlerAttribute timeoutInterceptor = methodInfo.GetCustomAttributes<TimeoutInterceptorCallHandlerAttribute>(true).FirstOrDefault();
            if (timeoutInterceptor != null)
            {
                _log.Info($"Method:[{invocation.Method.Name}] Param[{string.Join(",", invocation.Arguments.Select(a => a ?? "").ToString())}]");
                //adminToken
                //悲观超时（无法终止后续任务，仅仅抛出异常）=》乐观超时
                Policy timeoutPolicy = Policy.Timeout(timeoutInterceptor.Timeout,Polly.Timeout.TimeoutStrategy.Pessimistic,(a,b,c)=> {
                    _log.Info($"timeout"); 
                });
                try
                {
                    timeoutPolicy.Execute(
                    () =>
                    {
                        invocation.Proceed();
                    }
                    );
                }
                catch
                {

                }
            }
            else
            {
                invocation.Proceed();
            }

        }
    }
}

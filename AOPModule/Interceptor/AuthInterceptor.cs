﻿using Castle.DynamicProxy;
using InterfaceCenter;
using InterfaceCenter.DefAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOPModule
{
    public class AuthInterceptor : IAuthInterceptor
    {
        private ILogger _log;
        public AuthInterceptor(ILogger log)
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
            AuthInterceptorCallHandlerAttribute authInterceptor = methodInfo.GetCustomAttributes<AuthInterceptorCallHandlerAttribute>(true).FirstOrDefault();
            if (authInterceptor != null)
            {
                _log.Info($"Method:[{invocation.Method.Name}] Param[{string.Join(",", invocation.Arguments.Select(a => a ?? "").ToString())}]");
                //adminToken
                if (invocation.Arguments!= null&& invocation.Arguments.Count()>0 && invocation.Arguments[0].ToString().Equals("ABC"))
                {
                    _log.Info($"[{authInterceptor.ObjID}] Token is right!");
                    invocation.Proceed();
                    _log.Info($"Method:[{invocation.Method.Name}] is done!");
                }
                else
                {
                    _log.Info($"You can't use this Method[{invocation.Method.Name}]");
                }
            }
            else
            {
                invocation.Proceed();
            }

        }
    }
}

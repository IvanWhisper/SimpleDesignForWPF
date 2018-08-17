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
    /// <summary>
    /// 业务类
    /// </summary>
    [Intercept(typeof(IAuthInterceptor))]//设置拦截组件
    [Intercept(typeof(ITimeoutInterceptor))]//设置拦截组件
    [Intercept(typeof(ITimeconsumingInterceptor))]//设置拦截组件
    public class Work : IWork
    {
        private ILogger _log;
        private ICache _cache;
        private static string token;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="log"></param>
        /// <param name="cache"></param>
        public Work(ILogger log,ICache cache)
        {
            //依赖自动注入
            _log = log;
            _cache = cache;
            token = _cache.Token;
        }

        [AuthInterceptorCallHandler]//开启权限拦截服务
        [TimeConsumingInterceptorCallHandlerAttribute]//开启权限拦截服务
        public void DoSomething(string Token,string param)
        {
            _log.Info("Working working working!");
        }
        [AuthInterceptorCallHandler]
        [TimeoutInterceptorCallHandler(Timeout =3)]
        [TimeConsumingInterceptorCallHandlerAttribute]//开启方法执行耗时拦截服务
        public void DoMorething(string Token,string param)
        {
            //刻意超时
            Thread.Sleep(10000);
            _log.Info("More Working More working More working!");
        }
    }
}

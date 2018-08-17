using InterfaceCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CacheModule.Cache
{
    public class TestCache : ICache
    {
        private string _token;
        public string Token
        {
            get { return _token; }
            set
            {
                //模拟过期
                if (string.IsNullOrEmpty(value))
                    Task.Run(() =>
                    {
                        Thread.Sleep(30000);
                        //Task.Delay(300000);
                        _token = "";
                    });
                _token = value;
            }
        }
    }
}

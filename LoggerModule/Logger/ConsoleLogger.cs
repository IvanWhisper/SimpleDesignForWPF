using InterfaceCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerModule
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
            MessageBuild("ConsoleLogger is created!");
        }

        public void Debug(string message) => MessageBuild(message);
        public void Error(string message) => MessageBuild(message);
        public void Info(string message) => MessageBuild(message);

        public void MessageBuild(string msg)
        {
            Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss,fff")} {msg}");
        }
    }
}

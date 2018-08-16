using InterfaceCenter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerModule
{
    public class TextLogger : ILogger
    {
        private string path = @".\testlog.txt";
        public TextLogger()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            WriteMessage(path, "TextLogger is created!");
        }

        public void Debug(string message) => WriteMessage(path,message);
        public void Error(string message) => WriteMessage(path, message);
        public void Info(string message) => WriteMessage(path, message);

        public void WriteMessage(string path, string msg)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss,fff")} {msg}");
                    sw.Flush();
                }
            }
        }
    }
}

using GalaSoft.MvvmLight.Threading;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFWithAOPClient.View;
using WPFWithAOPClient.ViewModel;

namespace WPFWithAOPClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ConcurrentDictionary<string, Window> WindowDict = new ConcurrentDictionary<string, Window>();
        public App()
        {
            DispatcherHelper.Initialize();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            StartupUri = new Uri("MainWindow.xaml", UriKind.RelativeOrAbsolute);
        }
        public static Window GetWindow(string viewName)
        {
            if (!WindowDict.ContainsKey(viewName))
            {
                switch (viewName)
                {
                    case "login":
                        return new Login();
                    case "main":
                        return new MainWindow();
                    default:
                        return null;
                }
            }
            return WindowDict[viewName];
        }
    }
}

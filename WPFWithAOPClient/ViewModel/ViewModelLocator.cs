/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WPFWithAOPClient"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Autofac;
using GalaSoft.MvvmLight.Views;
using InterfaceCenter;
using System.IO;
using System.Reflection;
using System.Windows;
using WPFWithAOPClient.View;

namespace WPFWithAOPClient.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// IOCContainer
        /// IOC����
        /// </summary>
        public static IContainer Container { get; set; }
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();
            //local Register һ��ע��
            builder.RegisterType<MainViewModel>().AsSelf().SingleInstance();
            builder.RegisterType<LoginViewModel>().AsSelf().SingleInstance();


            //Scan Register ɨ��ע�� ÿ��ģ���ڲ��ж�Ӧģ���ע�᷽��
            var files = new DirectoryInfo(@".\ModuleLib\").GetFiles("*Module.dll");
            if (files != null && files.Length > 0)
            {
                foreach(var item in files)
                {
                    builder.RegisterAssemblyModules(Assembly.LoadFile(item.FullName));
                }
            }
            Container = builder.Build();
        }
        /// <summary>
        /// MainView��ViewModel
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return Container.Resolve<MainViewModel>();
            }
        }
        /// <summary>
        /// MainView��ViewModel
        /// </summary>
        public LoginViewModel Login
        {
            get
            {
                return Container.Resolve<LoginViewModel>();
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            Container.Dispose();
            Container = null;
        }
    }
}
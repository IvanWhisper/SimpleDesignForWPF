using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using InterfaceCenter;
using System;
using System.Threading.Tasks;

namespace WPFWithAOPClient.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ILogger _log;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(ILogger log)
        {
            this._log = log;
            Task.Run(()=> {
                while (true)
                {
                    Task.Delay(1000);
                    Welcome = DateTime.Now.ToString();
                }
            });
            _log.Debug("123");
            
        }
        private string welcome;
  
        public string Welcome
        {
            get { return welcome; }
            set {
                welcome = value;
                RaisePropertyChanged(() => Welcome);
            }
        }
        private RelayCommand loginSubmit;
        public RelayCommand LoginSubmit
        {
            get
            {
                if (loginSubmit == null) return new RelayCommand(() => Login());
                return loginSubmit;
            }
            set { loginSubmit = value; }
        }
        private RelayCommand doSomethingSubmit;
        public RelayCommand DoSomethingSubmit
        {
            get
            {
                if (doSomethingSubmit == null) return new RelayCommand(() => DoWork());
                return loginSubmit;
            }
            set { doSomethingSubmit = value; }
        }

        private void DoWork()
        {
            using (var scope = ViewModelLocator.Container.BeginLifetimeScope())
            {
                var cache = scope.Resolve<ICache>();
                var work = scope.Resolve<IWork>();
                work.DoSomething(cache.Token, "something 12345");
                work.DoMorething(cache.Token, "morething 6789");
            }

        }

        private void Login()
        {
            using (var scope = ViewModelLocator.Container.BeginLifetimeScope())
            {
                var cache = scope.Resolve<ICache>();
                cache.Token = "ABC";
            }
        }
    }
}
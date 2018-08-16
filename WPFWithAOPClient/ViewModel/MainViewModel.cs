using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Threading;
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
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            Task.Run(()=> {
                while (true)
                {
                    Task.Delay(1000);
                    Welcome = DateTime.Now.ToString();
                }
            });
        }
        private string welcome;
        /// <summary>
        /// ª∂”≠¥  Ù–‘
        /// </summary>
        public string Welcome
        {
            get { return welcome; }
            set {
                welcome = value;
                RaisePropertyChanged(() => Welcome);
            }
        }
    }
}
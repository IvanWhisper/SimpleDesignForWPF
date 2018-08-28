using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFWithAOPClient.View;

namespace WPFWithAOPClient.ViewModel
{
    /// <summary>
    /// Cancel
    /// </summary>
    public class NavigationService : INavigationService
    {
        private ConcurrentDictionary<string, Window> Views = new ConcurrentDictionary<string, Window>();
        private string _prevPageKey = string.Empty;
        private string _currentPageKey = string.Empty;
        public NavigationService()
        {
            InitialViews();
        }
        public void InitialViews()
        {
            Messenger.Default.Register<string>(this, "navigation", e =>_prevPageKey = e);
        }
        public void UnInitialViews()
        {
            Messenger.Default.Unregister<string>(this, "navigation");
        }
        public Window CreateWindow(string pageKey)
        {
            switch (pageKey)
            {
                case "login":
                    return new Login();
                case "main":
                    return new MainWindow();
                default:
                    return null;

            }
        }
        public string CurrentPageKey
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string PrevPageKey
        {
            get
            {
                return _prevPageKey;
            }
        }

        private Window GetView(string key)
        {
            return Views[key];
        }
        private bool AddView(string key,Window view)
        {
            return Views.TryAdd(key, view);
        }
        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            OnUI(() =>
            {
                if (!Views.ContainsKey(pageKey))
                    Views.TryAdd(pageKey,CreateWindow(pageKey));
                var view = GetView(pageKey);
                view.Show();
                view.Activate();
                if(!string.IsNullOrEmpty(_prevPageKey))
                    GetView(_prevPageKey).Hide();
                _prevPageKey = _currentPageKey;
                _currentPageKey = pageKey;
            });
        }
        public void OnUI(Action action)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(action);
        }
    }
}

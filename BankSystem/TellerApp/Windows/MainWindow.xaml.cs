using DatabaseLibrary.Models.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TellerApp.Pages;
using WpfLibrary.Models;
using WpfLibrary.Models.Interfaces;

namespace TellerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        private Dictionary<string, IPage> _pages;
        private string _activePageKey;
        private BankWorker? _user;

        public BankWorker AuthenticatedUser
        {
            get
            {
                if (_user is null)
                    throw new NullReferenceException("User is null!");

                return _user;
            }
        }

        public MainWindow()
        {
            _pages = new Dictionary<string, IPage>();
            _activePageKey = "";
            _user = null;
            InitializeComponent();

            //add pages here...
            _pages.Add("login", new LogInPage(this));
            _pages.Add("home", new HomePage(this));

            ChangePage("login");
        }

        public IPage GetPage(string key)
        {
            if (!_pages.ContainsKey(key))
                throw new ArgumentException($"There is no page called '{key}'.");

            return _pages[key];
        }

        public IPage GetActivePage()
        {
            if (_activePageKey == "")
                throw new Exception($"There is no active page.");

            return _pages[_activePageKey];
        }

        public void AddPage(string key, IPage page)
        {
            if (_pages.ContainsKey(key))
                throw new ArgumentException($"Page called {key} already exists.");

            _pages.Add(key, page);
        }

        public void ChangePage(string key)
        {
            if (!_pages.ContainsKey(key))
                throw new ArgumentException($"There is no page called '{key}'.");


            if (_activePageKey != "")
                _pages[_activePageKey].Close();

            PageFrame.Content = _pages[key];
            this.Width = _pages[key].DesiredWidth;
            this.Height = _pages[key].DesiredHeight;
            _activePageKey = key;
        }

        public void LogIn(BankWorker worker)
        {
            _user = worker;

            //Log in all other pages
            foreach (IPage page in _pages.Values)
                page.LogIn(_user);
        }

        public void LogOut()
        {
            _user = null;

            //Log out all other pages
            foreach (IPage page in _pages.Values)
                page.LogOut();
        }
    }
}

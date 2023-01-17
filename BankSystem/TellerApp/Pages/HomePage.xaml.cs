using DatabaseLibrary.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfLibrary.Models.Interfaces;

namespace TellerApp.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page, IPage
    {
        private BankWorker? _user = null;
        private IWindow? _owner = null;

        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(IWindow owner)
        {
            _owner = owner;
            InitializeComponent();
        }

        public int DesiredHeight => 600;
        public int DesiredWidth => 800;

        public BankWorker AuthenticatedUser
        {
            get
            {
                if (_user is null)
                    throw new NullReferenceException("User is null!");

                return _user;
            }
        }

        public IWindow Owner
        {
            get
            {
                if (_owner is null)
                    throw new NullReferenceException("Owner page is null!");

                return _owner;
            }
        }

        public bool AreAllFormsEmpty()
        {
            throw new NotImplementedException();
        }

        public void ClearAllFields()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void LogIn(BankWorker worker)
        {
            _user = worker;

            //Log in subpages
        }

        public void LogOut()
        {
            _user = null;

            //Log out subpages
        }
    }
}

using DatabaseLibrary.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
using WpfLibrary.Models.UserControls;

namespace TellerApp.Pages
{
    /// <summary>
    /// Interaction logic for LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page, IPage
    {
        private BankWorker? _user = null;
        private IWindow? _owner = null;

        public LogInPage()
        {
            InitializeComponent();
        }
        public LogInPage(IWindow owner)
        {
            _owner = owner;
            InitializeComponent();
        }

        public int DesiredHeight => 250;
        public int DesiredWidth => 500;

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
            return loginform.AreAllFieldsEmpty();
        }

        public void ClearAllFields()
        {
            loginform.ClearFields();
        }

        public void Close()
        {
            //Popup if not empty!

            loginform.Close();
        }

        public void LogIn(BankWorker worker)
        {
            _user = worker;
            //Log in all other subpages?
        }

        public void LogOut()
        {
            _user = null;
            //Log out all other subpages?
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            using (BankDBContext dBContext = new BankDBContext())
            {
                //if the table for bank workers is empty, prompt the user to create
                //a new user -> user control
                if (dBContext.BankWorkers.Count() == 0)
                    ;//This should call the create person and create bankworker
#warning Call uc as popup to create a person and bankworker in an empty database


                Tuple<string, string> formResultTuple = (Tuple<string, string>)loginform.GetResult();
                BankWorker? worker = dBContext
                    .BankWorkers
                    .Where(bw => bw.Username == formResultTuple.Item1 &&
                                 bw.Password == formResultTuple.Item2)
                    .FirstOrDefault();
                if (worker is null)
                    throw new Exception("Wrong credentials!");

                //successfully logged in!
                Owner.LogIn(worker);
                Owner.ChangePage("home");

            }
        }
    }
}

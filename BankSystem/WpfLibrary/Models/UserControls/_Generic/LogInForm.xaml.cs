using DatabaseLibrary.Models.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

namespace WpfLibrary.Models.UserControls
{
    /// <summary>
    /// Interaction logic for LogInForm.xaml
    /// </summary>
    public partial class LogInForm : UserControl, IUserControlForm
    {
        public object Monad { get; private set; }

        public IPage Owner { get; init; }

        public LogInForm()
        {
            Owner = null;
            InitializeComponent();
        }
        public LogInForm(IPage Owner)
        {
            this.Owner = Owner;
            InitializeComponent();
        }

        public bool AreAllFieldsEmpty()
        {
            return Tb_Username.Text == null &&
                   Pb_Password.Password == null;
        }
        public bool IsAnyFieldEmpty()
        {
            return Tb_Username.Text == null ||
                   Pb_Password.Password == null;
        }

        public void ClearFields()
        {
            Tb_Username.Clear();
            Pb_Password.Clear();
        }

        public void Close()
        {
            ClearFields();
        }

        public object GetResult()
        {
            if (IsAnyFieldEmpty())
                throw new Exception("All fields are required!");

            return new Tuple<string, string>(Tb_Username.Text, Pb_Password.Password);
        }

        //IDK how to implement a button call from here
        //the container needs to call GetData or whatever it is called
        //this is to happen when Btn_Submit is clicked

        //have the this.Owner call the GetValue function and
        //change page based on that...
    }
}

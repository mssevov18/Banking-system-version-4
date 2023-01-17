using DatabaseLibrary.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary.Models.Interfaces
{
    public interface ILoggedIn
    {
        public BankWorker AuthenticatedUser { get; }

        public void LogIn(BankWorker worker);
        public void LogOut();
    }
}

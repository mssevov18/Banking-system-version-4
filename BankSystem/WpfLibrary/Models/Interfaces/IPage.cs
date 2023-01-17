using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary.Models.Interfaces
{
    public interface IPage: ILoggedIn
    {
        public int DesiredHeight { get; }
        public int DesiredWidth { get; }

        public IWindow Owner { get; }

        /// <summary>
        /// TODO: Add a popup if a form is not empty!!!! _ _ _ 
        /// Handles all matters before declaring the page "closed".
        /// Clears all forms, etc.
        /// </summary>
        public void Close();

        public bool AreAllFormsEmpty();
        public void ClearAllFields();
    }
}

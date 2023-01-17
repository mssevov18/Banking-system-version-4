using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary.Models.Interfaces
{    
     /// <summary>
     /// An interface for a user control that returns data
     /// </summary>
    public interface IUserControlForm : IUserControl
    {

        /// <summary>
        /// Returns true if all fields are empty
        /// </summary>
        /// <returns>Result</returns>
        public bool AreAllFieldsEmpty();

        /// <summary>
        /// Returns true if any field is empty
        /// </summary>
        /// <returns></returns>
        public bool IsAnyFieldEmpty();

        /// <summary>
        /// Clears all fields
        /// </summary>
        public void ClearFields();

        /// <summary>
        /// Returns the result of the form.
        /// </summary>
        /// <returns>An object that represents the result </returns>
        public object GetResult();
    }
}

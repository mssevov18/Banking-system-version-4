using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary.Models.Interfaces
{
    /// <summary>
    /// An interface for a user control
    /// </summary>
    public interface IUserControl
    {
        public IPage Owner { get; init; }

        /// <summary>
        /// Handles all matters before declaring the user control form "closed".
        /// Clears all text boxes, etc.
        /// </summary>
        public void Close();
    }
}

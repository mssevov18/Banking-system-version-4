using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfLibrary.Models.Interfaces
{
    public interface IWindow: ILoggedIn
    {
        /// <summary>
        /// Gets the page from the dictionary.
        /// </summary>
        /// <param name="key">The name of the page.</param>
        /// <returns>The page</returns>
        /// <exception cref="ArgumentException"></exception>
        public IPage GetPage(string key);

        /// <summary>
        /// Gets the active page from the dictionary.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IPage GetActivePage();

        /// <summary>
        /// Adds a page to the dictionary.
        /// </summary>
        /// <param name="key">The name of the page.</param>
        /// <param name="page">The page</param>
        /// <exception cref="ArgumentException"></exception>
        public void AddPage(string key, IPage page);

        /// <summary>
        /// Changes the active page to the one given.
        /// </summary>
        /// <param name="key">The name of the page.</param>
        /// <exception cref="NullReferenceException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void ChangePage(string key);
    }
}

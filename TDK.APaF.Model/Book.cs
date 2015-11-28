using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Simple book info
    /// </summary>
    public class Book
    {
        #region Properties
        /// <summary>
        /// Title of book
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// ISBN
        /// </summary>
        public string ISBN { get; set; }
        /// <summary>
        /// Authors
        /// </summary>
        public string Authors { get; set; }
        #endregion
    }
}

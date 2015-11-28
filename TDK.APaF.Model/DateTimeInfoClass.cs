using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Used for tracking changes. Might be replaced when version control is handeled in <see cref="Creatures"/>
    /// </summary>
    public class DateTimeInfoClass
    {
        #region Properties
        /// <summary>
        /// Id 
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The data and time 
        /// </summary>
        public DateTime DateTime { get; set; }
        /// <summary>
        /// Name of the user
        /// </summary>
        public string User { get; set; }
        #endregion
    }
}

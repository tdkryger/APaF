using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.Model
{
    /// <summary>
    /// Class to hold min/max decimal values
    /// </summary>
    public class DecimalClass
    {
        #region Properties
        /// <summary>
        /// The minimum value
        /// </summary>
        public virtual decimal MinValue { get; set; }
        /// <summary>
        /// The maximum value
        /// </summary>
        public virtual decimal MaxValue { get; set; }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns a formated string with both values with 1 decimal
        /// </summary>
        /// <returns>Returns a formated string with both values with 1 decimal</returns>
        public override string ToString()
        {
            return string.Format("{0:1} - {1:1}", MinValue, MaxValue);
        }
        #endregion
    }
}

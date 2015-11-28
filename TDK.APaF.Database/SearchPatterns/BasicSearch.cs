using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database.SearchPatterns
{
    /// <summary>
    /// Basic search class
    /// </summary>
    public abstract class BasicSearch
    {
        #region Properties
        /// <summary>
        /// Latin Name
        /// </summary>
        Model.LatinNameClass LatinName { get; set; }
        #endregion


        #region Public methods
        /// <summary>
        /// Returns a string of fields and values for searching
        /// </summary>
        /// <returns>String for where part of sql</returns>
        public abstract string GetWhereClause();
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database.SearchPatterns
{
    /// <summary>
    /// Search for scientific name
    /// </summary>
    public class SearchSciName: BasicSearch
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
        public override string GetWhereClause()
        {
            return string.Format(" WHERE scientificNameId={0};", LatinName.ID);
        }
        #endregion
    }
}

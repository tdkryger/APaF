using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database.SearchPatterns
{
    /// <summary>
    /// Search pattern for Crustacean
    /// </summary>
    public class SearchCrustacean : BasicSearch
    {
        /// <summary>
        /// Returns a string of fields and values for searching
        /// </summary>
        /// <returns>String for where part of sql</returns>
        public override string GetWhereClause()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database.Delegates
{
    /// <summary>
    /// Events for database delegates
    /// </summary>
    public class DatabaseArgs: EventArgs
    {
        #region Properties
        /// <summary>
        /// The exception. Null if no exception
        /// </summary>
        public SqlException InnerException { get; protected set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ex">SQL Exception. Null if no exception</param>
        public DatabaseArgs(SqlException ex)
        {
            InnerException = ex;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database
{
    /// <summary>
    /// Config class for a database connection
    /// </summary>
    public class DatabaseConfig
    {
        #region enums  
        /// <summary>
        /// The database type
        /// </summary>
        public enum DatabaseTypes {
            /// <summary>
            /// Database not set!
            /// </summary>
            Unknown,
            /// <summary>
            /// Database is a MySQL
            /// </summary>
            MySQL };
        #endregion

        #region Fields
        private string _serverIp = string.Empty;
        private string _schema = string.Empty;
        private string _username = string.Empty;
        private string _password = string.Empty;

        #endregion

        #region Properties
        /// <summary>
        /// Server Ip for database
        /// </summary>
        public string ServerIp { get { return _serverIp; } }
        /// <summary>
        /// Schema/database name
        /// </summary>
        public string Schema { get { return _schema; } }
        /// <summary>
        /// Username for the database user
        /// </summary>
        public string Username { get { return _username; } }
        /// <summary>
        /// Password for the database user
        /// </summary>
        public string Password { get { return _password; } }
        /// <summary>
        /// The database type <see cref="DatabaseTypes"/>
        /// </summary>
        public DatabaseTypes DatabaseType { get; protected set; }
        #endregion


        #region Constructors
        /// <summary>
        /// Constructor...
        /// </summary>
        public DatabaseConfig(string serverIp, string schema, string username, string password, DatabaseTypes dbType=DatabaseTypes.MySQL)
        {
            _serverIp = serverIp;
            _schema = schema;
            _username = username;
            _password = password;
            DatabaseType = dbType;
        }
        #endregion
    }
}

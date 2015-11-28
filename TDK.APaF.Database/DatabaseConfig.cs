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
        #region Fields
        private string _serverIp = string.Empty;
        private string _schema = string.Empty;
        private string _username = string.Empty;
        private string _password = string.Empty;

        #endregion

        #region Properties
        public string ServerIp { get { return _serverIp; } }
        public string Schema { get { return _schema; } }
        public string Username { get { return _username; } }
        public string Password { get { return _password; } }
        #endregion


        #region Constructors
        /// <summary>
        /// Constructor...
        /// </summary>
        public DatabaseConfig(string serverIp, string schema, string username, string password)
        {
            _serverIp = serverIp;
            _schema = schema;
            _username = username;
            _password = password;
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.FishbaseImport
{
    /// <summary>
    /// Class for importing fishdata from Fishbase.org
    /// </summary>
    public class FishBaseImport
    {
        #region private consts
        private const string DBConnectString = "Server={0};Database={1};Uid={2};Pwd={3};ConvertZeroDateTime=True;tablecache=true;DefaultTableCacheAge=30;UseCompression=True;Pooling=True;";
        #endregion

        #region Fields
        private Database.DatabaseConfig _xmlSource;
        private Database.DatabaseConfig _destination;
        #endregion

        #region Public methods
        /// <summary>
        /// Loads XML from local database
        /// </summary>
        public void ImportFromMySQL(Database.DatabaseConfig xmlSource, Database.DatabaseConfig destination)
        {
            _xmlSource = xmlSource;
            _destination = destination;

            XMLImport importer = new XMLImport();
            Database.MySQL.Database myDB = new Database.MySQL.Database(_destination);

            string connString = string.Format(DBConnectString, _xmlSource.ServerIp, _xmlSource.Schema, _xmlSource.Username, _xmlSource.Password);
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connString))
            {
                conn.Open();
                using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT `fishbaseId`, `genus`, `species`, `xmlSummary`, `xmlPointData`, `xmlCommonNames`, `xmlPhotos` FROM `fishbaseraw`;";

                    using (MySql.Data.MySqlClient.MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Model.FishClass fc = importer.Import(
                                reader.GetInt32("fishbaseId"),
                                reader.GetString("genus"),
                                reader.GetString("species"),
                                reader.GetString("xmlSummary"),
                                reader.GetString("xmlPointData"),
                                reader.GetString("xmlCommonNames"),
                                reader.GetString("xmlPhotos")
                                );
                            if (fc != null)
                            {
                                try
                                {
                                    myDB.CreateFish(fc);
                                }
                                catch (Database.Exceptions.CreatureAlreadyExists ex)
                                {
                                    myDB.UpdateFish(fc);
                                }
                            }
                        }
                    }


                }
            }
        }

        /// <summary>
        /// Loads XML from fishbase.org
        /// </summary>
        public void ImportFromOnlineSource()
        {

        }
        #endregion

        #region private methods
        #endregion

    }
}

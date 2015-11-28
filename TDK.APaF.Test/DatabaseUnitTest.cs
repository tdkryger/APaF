using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class DatabaseUnitTest
    {
        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DatabaseConnectTest()
        {
            TDK.APaF.Database.MySQL.Database myDB = new TDK.APaF.Database.MySQL.Database(
                new TDK.APaF.Database.DatabaseConfig("localhost", "apaf2", "anuser", "mWZwbVCruMsh"));

            Assert.IsNotNull(myDB);
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DatabaseConnectTestDirect()
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(
                "Server=localhost;Database=apaf2;Uid=anuser;Pwd=mWZwbVCruMsh;"))
            {
                conn.Open();

                Assert.IsTrue(conn.State == System.Data.ConnectionState.Open);
            }
        }
    }
}

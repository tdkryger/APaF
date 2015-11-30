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

        [TestMethod, TestCategory("Database"), Priority(1)]
        public void CreateAFish()
        {
            TDK.APaF.Database.MySQL.Database myDB = new TDK.APaF.Database.MySQL.Database(
                new TDK.APaF.Database.DatabaseConfig("localhost", "apaf2", "anuser", "mWZwbVCruMsh"));
            TDK.APaF.Model.Lists.BehaviorList behList = TDK.APaF.Model.Lists.BehaviorList.CreateDefaultList();

            TDK.APaF.Model.FishClass fish = new TDK.APaF.Model.FishClass()
            {
                ID = -1,
                AquaLogCode = "Test 1",
                Created = new TDK.APaF.Model.DateTimeInfoClass()
                {
                    DateTime = DateTime.Now,
                    ID = -1,
                    User = "Thomas"
                },
                CurrentVersion = 1.0M,
                DataSource = EnumDataSource.Aqualog,
                
                
            };
            fish.Behavior.Add(behList[0]);
            fish.Behavior.Add(behList[1]);

            Assert.AreNotEqual(-1, fish.ID);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDK.APaF.Database.MySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDK.APaF.Database.MySQL.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        private TDK.APaF.Database.IDatabase getDBConnection()
        {
            return new TDK.APaF.Database.MySQL.Database(new TDK.APaF.Database.DatabaseConfig("localhost", "apaf2", "anuser", "mWZwbVCruMsh"));
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DatabaseTest()
        {
            TDK.APaF.Database.MySQL.Database myDB = (TDK.APaF.Database.MySQL.Database)getDBConnection();

            Assert.IsNotNull(myDB);
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DatabaseConnectTestDirect()
        {
            using (MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection("Server=localhost;Database=apaf2;Uid=anuser;Pwd=mWZwbVCruMsh;"))
            {
                conn.Open();

                Assert.IsTrue(conn.State == System.Data.ConnectionState.Open);
            }
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UndeleteCreatureTest()
        {
            bool okResult = false;
            try
            {
                TDK.APaF.Database.MySQL.Database myDB = (TDK.APaF.Database.MySQL.Database)getDBConnection();
                okResult = myDB.UndeleteCreature(1);
            }
            catch(TDK.APaF.Database.Exceptions.CreatureNotFound)
            {
                Assert.Inconclusive("Creature not found");
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsTrue(okResult);
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void GetOldVersionTest()
        {
            List<Model.CreatureIdentification> lst = null;
            try
            {
                TDK.APaF.Database.MySQL.Database myDB = (TDK.APaF.Database.MySQL.Database)getDBConnection();
                lst = myDB.GetOldVersion(1);
            }
            catch (TDK.APaF.Database.Exceptions.CreatureNotFound)
            {
                Assert.Inconclusive("Creature not found");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            Assert.IsNotNull(lst);
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateCrustaceanTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateFishTest()
        {
            TDK.APaF.Database.MySQL.Database myDB = new TDK.APaF.Database.MySQL.Database(new TDK.APaF.Database.DatabaseConfig("localhost", "apaf2", "anuser", "mWZwbVCruMsh"));
            TDK.APaF.Model.Lists.BehaviorList behList = TDK.APaF.Model.Lists.BehaviorList.CreateDefaultList();

            TDK.APaF.Model.FishClass fish = new TDK.APaF.Model.FishClass()
            {
                ID = -1,
                AquaLogCode = "Test 1",
                CreatedByUser = "Test user",
                CreatedDateTime = DateTime.Now,
                CurrentVersion = 1.0M,
                DataSource = EnumDataSource.Aqualog,


            };
            fish.Behavior.Add(behList[0]);
            fish.Behavior.Add(behList[1]);

            Assert.AreNotEqual(-1, fish.ID);
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteCrustaceanTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteFishTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadCrustaceanTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadCrustaceanTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadFishTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadFishTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateCrustaceanTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateFishTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateReptileTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadReptileTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadReptileTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateReptileTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteReptileTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateGastropodaTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadGastropodaTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadGastropodaTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateGastropodaTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteGastropodaTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreatePlantTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadPlantTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadPlantTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdatePlantTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeletePlantTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateBehaviorTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBehaviorTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBehaviorTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBehaviorTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateBehaviorTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteBehaviorTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateBookTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBookTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBookTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBookTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateBookTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteBookTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateBottomTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBottomTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBottomTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadBottomTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateBottomTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteBottomTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateDecorationTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadDecorationTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadDecorationTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadDecorationTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateDecorationTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteDecorationTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateFoodTypeTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadFoodTypeTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadFoodTypeTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadFoodTypeTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateFoodTypeTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteFoodTypeTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateGrowthSpeedTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadGrowthSpeedTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadGrowthSpeedTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadGrowthSpeedTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateGrowthSpeedTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteGrowthSpeedTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateSwimmingPositionTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadSwimmingPositionTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadSwimmingPositionTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadSwimmingPositionTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateSwimmingPositionTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteSwimmingPositionTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateFamilyTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadFamilyTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadFamilyTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadFamilyTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateFamilyTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteFamilyTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateRegionTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadRegionTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadRegionTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadRegionTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateRegionTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteRegionTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateGroupTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadGroupTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadGroupTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadGroupTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateGroupTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteGroupTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateOrderTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadOrderTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadOrderTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadOrderTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateOrderTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteOrderTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateClassificationTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadClassificationTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadClassificationTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadClassificationTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateClassificationTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteClassificationTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateLatinNameTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadLatinNameTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadLatinNameTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadLatinNameTest2()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateLatinNameTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteLatinNameTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreatePlantZoneTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadPlantZoneTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadPlantZoneTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdatePlantZoneTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeletePlantZoneTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadDateTimeInfoTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void ReadDateTimeInfoTest1()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void UpdateDateTimeInfoTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void DeleteDateTimeInfoTest()
        {
            Assert.Fail("Not Implemented");
        }

        [TestMethod, TestCategory("Database"), Priority(0)]
        public void CreateDateTimeInfoTest()
        {
            Assert.Fail("Not Implemented");
        }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ModelUnitTest
    {
        //TODO: make more tests... ;o)

        [TestMethod, TestCategory("Model"), Priority(1)]
        public void CreatePlant()
        {
            TDK.APaF.Model.PlantClass item = new TDK.APaF.Model.PlantClass();
            Assert.IsNotNull(item);
        }

        [TestMethod, TestCategory("Model"), Priority(1)]
        public void CreateCrustacean()
        {
            TDK.APaF.Model.CrustaceanClass item = new TDK.APaF.Model.CrustaceanClass();
            Assert.IsNotNull(item);
        }

        [TestMethod, TestCategory("Model"), Priority(1)]
        public void CreateReptile()
        {
            TDK.APaF.Model.ReptileClass item = new TDK.APaF.Model.ReptileClass();
            Assert.IsNotNull(item);
        }

        [TestMethod, TestCategory("Model"), Priority(1)]
        public void CreateGastropoda()
        {
            TDK.APaF.Model.GastropodaClass item = new TDK.APaF.Model.GastropodaClass();
            Assert.IsNotNull(item);
        }

        [TestMethod, TestCategory("Model"), Priority(1)]
        public void CreateFish()
        {
            TDK.APaF.Model.FishClass item = new TDK.APaF.Model.FishClass();
            Assert.IsNotNull(item);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Programmingpad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Programmingpad.Tests
{
    [TestClass()]
    public class B52Tests
    {

        [TestMethod()]
        public void B52Test()
        {
            // Arrange
            B52 b52 = new B52();
            int expectInitWeight = 185000;
            int expectFuel = 0;

            // Act
            int actualWeight = b52.Weight;
            int actualFuel = b52.Fuel;

            // Assert
            Assert.AreEqual(expectInitWeight, actualWeight);
            Assert.AreEqual(expectFuel, actualFuel);
            Assert.IsNotNull(b52.LeftWing);
            Assert.IsNotNull(b52.RightWing);
            Assert.IsNotNull(b52.Bay);
        }

        [TestMethod()]
        public void CalcWeightTest()
        {
            // Arrange
            B52 b52 = new B52();
            b52.Fuel = 100000;
            b52.Weight = 200000;
            int expected = 300000;
            // Act
            int actual = b52.CalcWeight();
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void IsReadyForTakeOffTest()
        {
            // Arrange
            B52 b52 = new B52();
            bool expected = false;
            // Act
            bool actual = b52.IsReadyForTakeOff();
            // Assert
            Assert.AreEqual(expected, actual);

            b52.Fuel = 100000;
            expected = true;
            actual = b52.IsReadyForTakeOff();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            int expected = 0;
            // Act


            // Assert


        }

        /*
            Running unit tests on whether the other weapons can be added to the 3 specified storage
            areas of the B-52. The MALD and WCMD will fail the test when checking the bayStorage since
            there is an exception thrown. 
        */

        [TestMethod()]
        public void AddJASSMWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            int expected = 0;
            // Act

        }

        [TestMethod()]
        public void AddJDAMWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            int expected = 0;
            // Act

        }

        [TestMethod()]
        public void AddMALDWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            int expected = 0;
            // Act

        }

        [TestMethod()]
        public void AddWCMDWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            int expected = 0;


        }

        [TestMethod()]
        public void AddCALCMWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            int expected = 0;

        }

        [TestMethod()]
        public void AddALCMWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            int expected = 0;

        }

        [TestMethod()]
        public void AddFuelTest()
        {
            // Arrange
            B52 b52 = new B52();

            int expected = 0;
            // Act

        }

        [TestMethod()]
        public void AddNoFuelTest()
        {
            // Arrange
            B52 b52 = new B52();
            // Act
            // Assert
            Assert.ThrowsException<FuelErrorException>(() => b52.AddFuel(0));
        }

        [TestMethod()]
        public void AddOverFuelTest()
        {
            // Arrange
            B52 b52 = new B52();
            //Act
            // Assert
            Assert.ThrowsException<FuelErrorException>(() => b52.AddFuel(300001));
        }

        [TestMethod()]
        public void ClearWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();

            int expected = 185000;
            // Act
            int actual = b52.Weight;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ClearFuelTest()
        {
            // Arrange
            B52 b52 = new B52();

            int expected = 0;
            // Act
            int actual = b52.Fuel;
            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
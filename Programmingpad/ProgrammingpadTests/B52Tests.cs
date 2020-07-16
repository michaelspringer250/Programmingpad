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
            Assert.AreEqual(expected,actual);
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
            int actual = b52.AddWeapon(Storage.Left,Weapon.ALCM);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddFuelTest()
        {
            // Arrange
            B52 b52 = new B52();
            
            int expected = 0;
            // Act
            int actual = b52.AddFuel(100000);
            // Assert
            Assert.AreEqual(expected, actual);
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
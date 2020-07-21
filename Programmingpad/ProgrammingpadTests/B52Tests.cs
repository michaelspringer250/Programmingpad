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

        /*
            Running unit tests on whether the weapons can be added to the 3 specified storage
            areas of the B-52. The MALD and WCMD will fail the test when checking the bayStorage since
            there is an exception thrown. 
        */

        [TestMethod()]
        public void AddGravityWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            Weapon GravityWeapon = new Weapon(WeaponType.Gravity);
            int expected = 208964;

            // Act
            b52.AddWeapon(Storage.Left, GravityWeapon);
            b52.AddWeapon(Storage.Right, GravityWeapon); 
            b52.AddWeapon(Storage.Bay, GravityWeapon);
            int actual = b52.CalcWeight();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Left, GravityWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Right, GravityWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Bay, GravityWeapon));
        }

        [TestMethod()]
        public void OverWeightGravityTest()
        {
            B52 b52 = new B52();
            Weapon GravityWeapon = new Weapon(WeaponType.Gravity);
            b52.Weight = 485000;

            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Left, GravityWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Right, GravityWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Bay, GravityWeapon));
        }

        [TestMethod()]
        public void AddJASSMWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            Weapon JASSMWeapon = new Weapon(WeaponType.JASSM);
            int expected = 259838;

            // Act
            b52.AddWeapon(Storage.Left, JASSMWeapon);
            b52.AddWeapon(Storage.Right, JASSMWeapon);
            b52.AddWeapon(Storage.Bay, JASSMWeapon);
            int actual = b52.CalcWeight();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Left, JASSMWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Right, JASSMWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Bay, JASSMWeapon));
        }

        [TestMethod()]
        public void OverWeightJASSMTest()
        {
            B52 b52 = new B52();
            Weapon JASSMWeapon = new Weapon(WeaponType.JASSM);
            b52.Weight = 485000;

            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Left, JASSMWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Right, JASSMWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Bay, JASSMWeapon));
        }

        [TestMethod()]
        public void AddJDAMWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            Weapon JDAMWeapon = new Weapon(WeaponType.JDAM);
            int expected = 214166;

            // Act
            b52.AddWeapon(Storage.Left, JDAMWeapon);
            b52.AddWeapon(Storage.Right, JDAMWeapon);
            b52.AddWeapon(Storage.Bay, JDAMWeapon);
            int actual = b52.CalcWeight();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Left, JDAMWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Right, JDAMWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Bay, JDAMWeapon));
        }

        [TestMethod()]
        public void OverWeightJDAMTest()
        {
            B52 b52 = new B52();
            Weapon JDAMWeapon = new Weapon(WeaponType.JDAM);
            b52.Weight = 485000;

            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Left, JDAMWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Right, JDAMWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Bay, JDAMWeapon));
        }

        [TestMethod()]
        public void AddMALDWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            Weapon MALDWeapon = new Weapon(WeaponType.MALD);
            int expected = 200252;

            // Act
            b52.AddWeapon(Storage.Left, MALDWeapon);
            b52.AddWeapon(Storage.Right, MALDWeapon);
            int actual = b52.CalcWeight();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Left, MALDWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Right, MALDWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Bay, MALDWeapon));
        }

        [TestMethod()]
        public void OverWeightMALDTest()
        {
            B52 b52 = new B52();
            Weapon MALDWeapon = new Weapon(WeaponType.MALD);
            b52.Weight = 485000;

            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Left, MALDWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Right, MALDWeapon));
        }

        [TestMethod()]
        public void AddWCMDWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            Weapon WCMDWeapon = new Weapon(WeaponType.WCMD);
            int expected = 217648;

            // Act
            b52.AddWeapon(Storage.Left, WCMDWeapon);
            b52.AddWeapon(Storage.Right, WCMDWeapon);
            int actual = b52.CalcWeight();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Left, WCMDWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Right, WCMDWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Bay, WCMDWeapon));
        }

        [TestMethod()]
        public void OverWeightWCMDTest()
        {
            B52 b52 = new B52();
            Weapon WCMDWeapon = new Weapon(WeaponType.WCMD);
            b52.Weight = 485000;

            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Left, WCMDWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Right, WCMDWeapon));
        }

        [TestMethod()]
        public void AddCALCMWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            Weapon CALCMWeapon = new Weapon(WeaponType.CALCM);
            int expected = 275582;

            // Act
            b52.AddWeapon(Storage.Left, CALCMWeapon);
            b52.AddWeapon(Storage.Right, CALCMWeapon);
            b52.AddWeapon(Storage.Bay, CALCMWeapon);
            int actual = b52.CalcWeight();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Left, CALCMWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Right, CALCMWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Bay, CALCMWeapon));
        }

        [TestMethod()]
        public void OverWeightCALCMTest()
        {
            B52 b52 = new B52();
            Weapon CALCMWeapon = new Weapon(WeaponType.CALCM);
            b52.Weight = 485000;

            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Left, CALCMWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Right, CALCMWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Bay, CALCMWeapon));
        }

        [TestMethod()]
        public void AddALCMWeaponTest()
        {
            // Arrange
            B52 b52 = new B52();
            Weapon ALCMWeapon = new Weapon(WeaponType.ALCM);
            int expected = 275582;

            // Act
            b52.AddWeapon(Storage.Left, ALCMWeapon);
            b52.AddWeapon(Storage.Right, ALCMWeapon);
            b52.AddWeapon(Storage.Bay, ALCMWeapon);
            int actual = b52.CalcWeight();

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Left, ALCMWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Right, ALCMWeapon));
            Assert.ThrowsException<LoadErrorException>(() => b52.AddWeapon(Storage.Bay, ALCMWeapon));
        }

        [TestMethod()]
        public void OverWeightALCMTest()
        {
            B52 b52 = new B52();
            Weapon ALCMWeapon = new Weapon(WeaponType.ALCM);
            b52.Weight = 485000;

            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Left, ALCMWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Right, ALCMWeapon));
            Assert.ThrowsException<WeightErrorException>(() => b52.AddWeapon(Storage.Bay, ALCMWeapon));
        }

        [TestMethod()]
        public void AddFuelTest()
        {
            // Arrange
            B52 b52 = new B52();
            int expected = 100000; 

            // Act
            b52.AddFuel(100000);

            // Assert
            Assert.AreEqual(expected, b52.Fuel);
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
        public void TakeOffLimitTest()
        {
            // Arrange
            B52 b52 = new B52();
            b52.Weight = 200000;
            // Act
            // Assert
            Assert.ThrowsException<WeightErrorException>(() => b52.AddFuel(300000));
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
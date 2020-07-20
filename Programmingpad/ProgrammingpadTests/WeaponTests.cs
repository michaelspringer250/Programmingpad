using Microsoft.VisualStudio.TestTools.UnitTesting;
using Programmingpad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmingpad.Tests
{
    [TestClass()]
    public class WeaponTests
    {
        [TestMethod()]
        public void WeaponTest()
        {
            // Test default constructor
            // Arrange
            Weapon weapon = new Weapon();
            int expectedWeight = 0;
            int expectedQuantity = 0;
            WeaponType expectedType = WeaponType.NONE;
            // Act
            int actualWeight = weapon.Weight; ;
            int actualQuantity = weapon.Quantity;
            WeaponType actualType = weapon.Type;
            // Assert
            Assert.AreEqual(expectedWeight, actualWeight);
            Assert.AreEqual(expectedQuantity, actualQuantity);
            Assert.AreEqual(expectedType, actualType);

            // Test non default contructor
            // Arrange
            Weapon actual = new Weapon(WeaponType.Gravity);
            Weapon expect = new Weapon();
            // Act
            expect.Type = WeaponType.Gravity;
            expect.Weight = Weapon.GRAVITY_WEIGHT;
            expect.Quantity = 1;
            // Assert
            Assert.AreEqual(actual.Type, expect.Type);
            Assert.AreEqual(actual.Quantity, expect.Quantity);
            Assert.AreEqual(actual.Weight, expect.Weight);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Weapon weapon1 = new Weapon(WeaponType.ALCM);
            Weapon weapon2 = new Weapon(WeaponType.ALCM);
            bool expected = true;
            bool actual = weapon1.Equals(weapon2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Weapon weapon = new Weapon(WeaponType.Gravity);
            string expected = "1 Gravity";
            string actual = weapon.ToString();
            Assert.AreEqual(expected, actual);

        }
    }
}
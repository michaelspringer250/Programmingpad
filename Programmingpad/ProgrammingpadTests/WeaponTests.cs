using Microsoft.VisualStudio.TestTools.UnitTesting;
using Programmingpad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programmingpad.Tests
{
    /// <summary>
    /// Test the default and non default constructor
    /// </summary>
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

        /// <summary>
        /// Test the Equals method if two object are equal
        /// </summary>
        [TestMethod()]
        public void EqualsTest()
        {
            // Arrange
            Weapon weapon1 = new Weapon(WeaponType.ALCM);
            Weapon weapon2 = new Weapon(WeaponType.ALCM);
            // Act
            bool expected = true;
            bool actual = weapon1.Equals(weapon2);
            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test the ToString method represents the description of the weapon
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            Weapon weapon = new Weapon(WeaponType.Gravity);
            // Act
            string expected = "1 Gravity";
            string actual = weapon.ToString();
            // Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
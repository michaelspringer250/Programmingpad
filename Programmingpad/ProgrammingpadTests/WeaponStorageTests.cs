using Microsoft.VisualStudio.TestTools.UnitTesting;
using Programmingpad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Group 2 - B52 Tinker Project - ProgrammingPad
 * @Author Sydney Ninh
 * WeaponStorageTests.cs
 */

namespace Programmingpad.Tests
{
    /// <summary>
    /// Test the constructor
    /// </summary>
    [TestClass()]
    public class WeaponStorageTests
    {
       
        [TestMethod()]
        public void WeaponStorageTest()
        {

            WeaponStorage weaponstorage = new WeaponStorage();
            Assert.IsNotNull(weaponstorage.Storage);
        }

        /// <summary>
        /// Test ToString method represents the description of the weapon
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            WeaponStorage weaponstorage = new WeaponStorage();
            Weapon gravity = new Weapon(WeaponType.Gravity);
            // Act
            weaponstorage.AddWeapon(gravity);
            String expected = "1 Gravity";
            String actual = weaponstorage.ToString();
            // Assert
            Assert.AreEqual(actual, expected);

        }

        /// <summary>
        /// Test AddWeapon method
        /// </summary>
        [TestMethod()]
        public void AddWeaponTest()
        {
            // Arrange
            WeaponStorage weaponstorage = new WeaponStorage();
            Weapon gravity = new Weapon(WeaponType.Gravity);
            // Act
            weaponstorage.AddWeapon(gravity);
            bool expected = true;
            bool actual = weaponstorage.Contain(gravity);
            // Assert
            Assert.AreEqual(actual, expected);

        }

        /// <summary>
        /// Test the weight of the weapons
        /// </summary>
        [TestMethod()]
        public void CalcWeightTest()
        {
            // Arrange
            WeaponStorage weaponstorage = new WeaponStorage();
            Weapon weapon = new Weapon(WeaponType.Gravity);
            // Act
            weaponstorage.AddWeapon(weapon);
            weapon = new Weapon(WeaponType.JASSM);
            weapon.Quantity = 2;
            weaponstorage.AddWeapon(weapon);
            int expected = Weapon.GRAVITY_WEIGHT + Weapon.JASSM_WEIGHT*2;
            int actual = weaponstorage.CalcWeight();
            // Assert
            Assert.AreEqual(actual, expected);
        }

        /// <summary>
        /// Test the ClearWeapon method
        /// </summary>
        [TestMethod()]
        public void ClearWeaponTest()
        {
            // Arrange
            WeaponStorage weaponstorage = new WeaponStorage();
            Weapon weapon = new Weapon(WeaponType.Gravity);
            // Act
            weaponstorage.AddWeapon(weapon);
            weapon = new Weapon(WeaponType.JASSM);
            weapon.Quantity = 2;
            weaponstorage.AddWeapon(weapon);
            weaponstorage.ClearWeapon();
            int actual = weaponstorage.Storage.Count();
            int expected = 0;
            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
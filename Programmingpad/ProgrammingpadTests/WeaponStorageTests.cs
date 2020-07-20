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
    public class WeaponStorageTests
    {
       
        [TestMethod()]
        public void WeaponStorageTest()
        {

            WeaponStorage weaponstorage = new WeaponStorage();
            Assert.IsNotNull(weaponstorage.Storage);
        }

        [TestMethod()]
        public void ToStringTest()
        {

            WeaponStorage weaponstorage = new WeaponStorage();
            Weapon gravity = new Weapon(WeaponType.Gravity);
            weaponstorage.AddWeapon(gravity);
            String expected = "1 Gravity";
            String actual = weaponstorage.ToString();
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void AddWeaponTest()
        {
            WeaponStorage weaponstorage = new WeaponStorage();
            Weapon gravity = new Weapon(WeaponType.Gravity);
            weaponstorage.AddWeapon(gravity);
            bool expected = true;
            bool actual = weaponstorage.Contain(gravity);
            Assert.AreEqual(actual, expected);

        }

        [TestMethod()]
        public void CalcWeightTest()
        {
            WeaponStorage weaponstorage = new WeaponStorage();
            Weapon weapon = new Weapon(WeaponType.Gravity);
            weaponstorage.AddWeapon(weapon);
            weapon = new Weapon(WeaponType.JASSM);
            weapon.Quantity = 2;
            weaponstorage.AddWeapon(weapon);
            int expected = Weapon.GRAVITY_WEIGHT + Weapon.JASSM_WEIGHT*2;
            int actual = weaponstorage.CalcWeight();
            Assert.AreEqual(actual, expected);
        }

        [TestMethod()]
        public void ClearWeaponTest()
        {
            WeaponStorage weaponstorage = new WeaponStorage();
            Weapon weapon = new Weapon(WeaponType.Gravity);
            weaponstorage.AddWeapon(weapon);
            weapon = new Weapon(WeaponType.JASSM);
            weapon.Quantity = 2;
            weaponstorage.AddWeapon(weapon);
            weaponstorage.ClearWeapon();
            int actual = weaponstorage.Storage.Count();
            int expected = 0;
            Assert.AreEqual(actual, expected);
        }
    }
}
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
            Assert.Fail();
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddWeaponTest()
        {
            WeaponStorage actual = new WeaponStorage();
            int expected = 1;
            actual.AddWeapon(Weapon.ALCM);

            Assert.AreEqual(actual.ALCM, expected);
            Assert.ThrowsException<LoadErrorException>(() => actual.AddWeapon(Weapon.ALCM));
        }

        [TestMethod()]
        public void CalcWeightTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearWeaponTest()
        {
            Assert.Fail();
        }
    }
}
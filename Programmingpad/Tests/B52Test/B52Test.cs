using System;
using Programmingpad;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ProgrammingpadTest
{
    [TestClass]
    public class B52Test
    {
        [TestMethod]
        public void CalcWeightTest()
        {
            // Arrange
            B52 b52 = new B52();
            int _fuel = 100000;
            int expected = 285000;

            // Act
            int actual = b52.CaclWeight();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

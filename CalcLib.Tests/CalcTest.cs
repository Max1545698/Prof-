using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcLib;
namespace CalcLib.Tests
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void AddTest_2plus3_5return()
        {
            Calc c = new Calc();

            double x = 2, y = 3;
            double expected = x + y;
            double actual = c.Add(x, y);
            Assert.AreEqual(expected, actual);
        }
    }
}

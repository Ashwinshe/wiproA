using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorLibrary;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsCorrectSum()
        {
            Assert.AreEqual(10, calculator.Add(5, 5));
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsCorrectDifference()
        {
            Assert.AreEqual(5, calculator.Subtract(10, 5));
        }

        [TestMethod]
        public void Multiply_TwoNumbers_ReturnsCorrectProduct()
        {
            Assert.AreEqual(20, calculator.Multiply(4, 5));
        }

        [TestMethod]
        public void Divide_TwoNumbers_ReturnsCorrectQuotient()
        {
            Assert.AreEqual(2, calculator.Divide(10, 5));
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsException()
        {
            try
            {
                calculator.Divide(10, 0);
                Assert.Fail("Expected DivideByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}

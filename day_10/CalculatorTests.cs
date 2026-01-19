using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace day_10
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int result = calc.Add(10, 20);

            // Assert
            Assert.AreEqual(30, result);
        }

        [TestMethod]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int result = calc.Subtract(10, 3);

            // Assert
            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsException()
        {
            // Arrange
            Calculator calc = new Calculator();

            try
            {
                // Act
                calc.Divide(10, 0);

                // Assert (FAIL if no exception)
                Assert.Fail("Expected DivideByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {
                // Assert (PASS)
                Assert.IsTrue(true);
            }
        }
    }
}

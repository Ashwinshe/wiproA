using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace day_10
{
    [TestClass]
    public class CalculatorTests
    {
        // Multiple inputs for Add method
        [TestMethod]
        [DataRow(5, 3, 8)]        // simple numbers
        [DataRow(10, 20, 30)]     // positive numbers
        [DataRow(-5, -3, -8)]     // negative numbers
        [DataRow(12, -34, -22)]   // mixed numbers
        public void Add_MultipleInputs_ReturnsCorrectSum(int a, int b, int expected)
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int result = calc.Add(a, b);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(10, 3, 7)]
        [DataRow(20, 10, 10)]
        [DataRow(-5, -3, -2)]
        public void Subtract_MultipleInputs_ReturnsCorrectDifference(int a, int b, int expected)
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            int result = calc.Subtract(a, b);

            // Assert
            Assert.AreEqual(expected, result);
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
                Assert.Fail("Expected DivideByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {
                // success
            }
        }
    }
}

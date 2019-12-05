using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test
{
    [TestClass]
    public class InputConverterTest
    {
        private readonly InputConverter inputConverter = new InputConverter();

        [TestMethod]
        public void ConvertsStringIntoDouble()
        {
            double actual = inputConverter.ConvertInputToNumeric("12.5");
            double expected = 12.5;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailsToConvertStringToDouble()
        {
            double actual = inputConverter.ConvertInputToNumeric("asdafsd");
        }
    }
}
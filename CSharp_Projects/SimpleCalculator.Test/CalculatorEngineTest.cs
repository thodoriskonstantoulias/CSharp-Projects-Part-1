using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCalculator.Test
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine calculatorEngine = new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResult()
        {
            double actual = calculatorEngine.Calculate("add", 1, 2);
            double expected = 3;

            Assert.AreEqual(expected, actual);
        }
    }
}

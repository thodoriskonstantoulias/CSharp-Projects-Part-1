using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Strategies;
using SudokuSolver.Workers;

namespace SudokuSolver.Test.Strategies
{
    [TestClass]
    public class NakedPairStrategyTest
    {
        private readonly ISudokuStrategy _nakedPairStrategy = new NakedPairStrategy(new SudokuMapper());
        [TestMethod]
        public void ShouldEliminateNumbersInRow()
        {
            int[,] sudokuBoard =
            {
                {1,2,34,5,34,6,7,348,9},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0}
            };
            var solvedSudokuBoard = _nakedPairStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[0, 7] == 8);
        }
    }
}

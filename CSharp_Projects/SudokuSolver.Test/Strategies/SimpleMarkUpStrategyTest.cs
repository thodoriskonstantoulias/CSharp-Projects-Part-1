using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Strategies;
using SudokuSolver.Workers;

namespace SudokuSolver.Test.Strategies
{
    [TestClass]
    public class SimpleMarkUpStrategyTest
    {
        private readonly ISudokuStrategy _simpleMarkUpStrategy = new SimpleMarkUpStrategy(new SudokuMapper());

        [TestMethod]
        public void ShouldSolveForTopLeftCell()
        {
            int[,] sudokuBoard =
            {               
               {0,1,2,3,9,8,4,7,5},
               {5,3,8,4,1,7,6,2,9},
               {4,7,9,5,6,2,3,1,8},
               {9,6,7,2,8,4,1,5,3},
               {3,8,4,6,5,1,7,9,2},
               {2,5,1,7,3,9,8,6,4},
               {8,2,5,1,4,6,9,3,7},
               {1,9,3,8,7,5,2,4,6},
               {7,4,6,9,2,3,5,8,1}
            };
            var solvedSudokuBoard = _simpleMarkUpStrategy.Solve(sudokuBoard);

            Assert.IsTrue(solvedSudokuBoard[0,0] == 6);

        }
    }
}

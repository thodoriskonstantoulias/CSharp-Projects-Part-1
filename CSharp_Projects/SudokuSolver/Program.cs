using SudokuSolver.Strategies;
using SudokuSolver.Workers;
using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SudokuMapper sudokuMapper = new SudokuMapper();
                SudokuBoardStateManager sudokuBoardStateManager = new SudokuBoardStateManager();
                SudokuSolverEngine sudokuSolverEngine = new SudokuSolverEngine(sudokuBoardStateManager, sudokuMapper);
                SudokuFileReader sudokuFileReader = new SudokuFileReader();
                SudokuBoardDisplayer sudokuBoardDisplayer = new SudokuBoardDisplayer();

                Console.WriteLine("Please enter the file name containing the sudoku puzzle");
                var fileName = Console.ReadLine();

                var sudokuBoard = sudokuFileReader.ReadFile(fileName);
                sudokuBoardDisplayer.Display("Initial state", sudokuBoard);

                bool isSudokuSolved = sudokuSolverEngine.Solve(sudokuBoard);
                sudokuBoardDisplayer.Display("Final state", sudokuBoard);

                Console.WriteLine(isSudokuSolved ? "You have successfully solved this Sudoku Puzzle" : "Current algorithm(s) were not enough to solve the current Sudoku Puzzle");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sudoku puzzle cannot be solved because there was an arror " + ex.Message);
            }
        }
    }
}

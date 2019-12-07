using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SudokuSolver.Workers
{
    class SudokuFileReader
    {
        public int[,] ReadFile(string filename)
        {
            int[,] sudokuBoard = new int[9, 9];
            try
            {
                var sudokuBoardLines = File.ReadAllLines(filename);
                int row = 0;
                foreach (var line in sudokuBoardLines)
                {
                    string[] boardLines = line.Split("|").Skip(1).Take(9).ToArray();
                    int col = 0;
                    foreach (var inLine in boardLines)
                    {
                        sudokuBoard[row, col] = inLine.Equals(" ") ? 0 : Convert.ToInt16(inLine);
                        col++;
                    }
                    row++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong when reading the file : " + ex.Message);
            }
            return sudokuBoard;
        }
    }
}

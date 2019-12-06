using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    public class FileUnscrambler
    {       
        private static readonly FileReader _fileReader = new FileReader();

        public static void ExecuteScrambledWordsInFile()
        {
            Console.WriteLine(Constants.fileAdvice);
            try
            {
                string filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayWords.DisplayScrambledWords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }                     
        }
    }
}

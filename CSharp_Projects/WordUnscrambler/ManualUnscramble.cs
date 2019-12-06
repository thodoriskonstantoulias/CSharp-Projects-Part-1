using System;
using System.Collections.Generic;
using System.Text;

namespace WordUnscrambler
{
    public class ManualUnscramble
    {
        public static void ExecuteScrambledWordsManually()
        {
            Console.WriteLine("Enter scrambled word or words comma separated");
            string manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(",");
            DisplayWords.DisplayScrambledWords(scrambledWords);
        }

        
    }
}

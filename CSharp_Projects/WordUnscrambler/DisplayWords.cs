using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    public class DisplayWords
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        public static void DisplayScrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(Constants.fileName);
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var word in matchedWords)
                {
                    Console.WriteLine(Constants.matchesFound, word.ScrambledWord, word.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.matchesNotFound);
            }
        }
    }
}

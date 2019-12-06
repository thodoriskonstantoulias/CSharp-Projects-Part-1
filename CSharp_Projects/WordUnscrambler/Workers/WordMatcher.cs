using System;
using System.Collections.Generic;
using System.Text;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(new MatchedWord { ScrambledWord = scrambledWord, Word = word });
                    }
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);
                        var sortedScrambled = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);
                        if (sortedScrambled.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(new MatchedWord { ScrambledWord = scrambledWord, Word = word });
                        }
                    }
                }
            }
            return matchedWords;
        }
    }
}

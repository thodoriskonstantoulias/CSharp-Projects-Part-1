using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordUnscrambler.Workers;

namespace WordUnscrambler.Test
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();
        [TestMethod]
        public void ScrambledWordMatchesWordInList()
        {
            string[] wordList = {"cat","chair","more"};
            string[] scrambledWords = { "omre" };
            var matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].ScrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
        }
    }
}

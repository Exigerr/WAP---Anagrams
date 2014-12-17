using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.IO;
using AnagramAPI;

namespace UnitTests {
    [TestClass]
    public class WordSearch {

        private Dictionary<string, List<string>> _wordList = new Dictionary<string, List<string>>();
        private string _dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private Searcher _searcher = new Searcher();

        [TestInitialize]
        public void SetUp() {
            string fileLocation = _dir + @"../../anagramApp/Assets/Words/wordlist.txt";
            var reader = new WordReader(fileLocation);
            _searcher.SetList(reader.GetList(_wordList));
        }

        [TestMethod]
        public void ContainsWord() {
            Assert.IsNotNull(_searcher.GetWord("angor"));
        }

        [TestMethod]
        public void ResultsMatch() {
            //Check if result output is what is should be, when searching "realist"
            var results = new List<string>();
            results.Add("Aletris");
            results.Add("Alister");
            results.Add("Listera");
            results.Add("realist");
            results.Add("saltier");

            var searchResults = _searcher.GetWord("realist");
            bool equal = searchResults.SequenceEqual(results);
            Assert.AreEqual(true, equal);
        }

        [TestMethod]
        public void NoResults() {
            Assert.IsNull(_searcher.GetWord("WordDoesNotExist0123"));
        }
    }
}

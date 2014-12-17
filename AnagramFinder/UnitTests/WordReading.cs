using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.IO;
using AnagramAPI;


namespace UnitTests {
    [TestClass]
    public class WordReading {

        private WordReader _reader;
        private string _dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        private Dictionary<string, List<string>> _dict = new Dictionary<string, List<string>>();

        [TestInitialize]
        public void SetUp() {
            string fileLocation = _dir +@"../../anagramApp/Assets/Words/wordlist.txt";
            _reader = new WordReader(fileLocation);
        }

        [TestMethod]
        public void IsValidLocation() {
            Assert.IsInstanceOfType(_reader.GetList(_dict), typeof(Dictionary<string, List<string>>));
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "Couldn't find file")]
        public void IsInvalidLocation() {
            string fileLocation = _dir + @"../../anagramApp/Assets/Words/DoesNotExist.txt";
            var reader = new WordReader(fileLocation);
            reader.GetList(_dict);
        }
    }
}

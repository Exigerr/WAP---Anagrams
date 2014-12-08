using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMatrix.Data;

namespace anagramApp.Classes {
    public class AnagramDbHandler {

        private Database _db;

        public AnagramDbHandler(Database dbName) {
            _db = dbName;
        }

        public void UpdateStoredList(Dictionary<string, List<string>> wordList) {

            int id;
            foreach (var item in wordList) {
                id = InsertAnagram(item.Key);
                InsertWords(item.Value, id);
            }

        }

        public Dictionary<string, List<string>> GetPopularList() {
            string getQuery = "SELECT TOP 1000, Words.word, Anagrams.anagram FROM Words INNER JOIN Anagrams ON Words.anagramId = Anagrams.Id ORDER BY Anagrams.popularity";
            return new Dictionary<string, List<string>>();
        }

        public int InsertAnagram(string value) {
            string anagramQuery = "INSERT INTO Anagrams (anagram) SELECT @param0 WHERE NOT EXISTS (SELECT anagram FROM Anagrams WHERE anagram=@param0)";
            string getAnagramId = "SELECT Id FROM Anagrams WHERE anagram = @param0";
            int id;

            if (_db.Execute(anagramQuery, value) < 1) {
                id = _db.GetLastInsertId();
            }
            else {
                var result = _db.QueryValue(getAnagramId, value);
                id = result.Id;
            }

            return id;
        }

        public void InsertWords(List<string> list, int id) {
            string wordQuery = "INSERT INTO Words (word, anagramId) SELECT @param0, @param1 WHERE NOT EXISTS (SELECT word FROM Words WHERE word=@param0)";

            foreach (var word in list) {
                _db.Execute(wordQuery, word, id);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramAPI
{
    public class Searcher : Words {

        private Dictionary<string, List<string>> _wordList;
        private List<string> _results = null;

        public Boolean SetList (Dictionary<string, List<string>> list) {
            if (list == null) {
                return false;
            }

            _wordList = list;
            return true;
        }

        public List<string> GetWord(string word, Action<string> Callback = null) {
            _wordList.TryGetValue(Alphabetise(word.ToLower()), out _results);

            if(Callback != null){
                Callback.Invoke(word);
            }

            return _results;
        }

    }
}

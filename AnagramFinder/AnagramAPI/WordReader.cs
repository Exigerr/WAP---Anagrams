using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnagramAPI
{
    public class WordReader : Words {
        private string _filename;

        public WordReader(string filename) {
            //"/Assets/Words/"+_filename
            _filename = filename;
        }

        public Dictionary<string, List<string>> GetList(Dictionary<string, List<string>> sortedList) {

            using (StreamReader file = new StreamReader(_filename)) {
                string line;

                while ((line = file.ReadLine()) != null) {
                    string key = Alphabetise(line);
                    List<string> value;

                    //Check if key already exists
                    if (sortedList.TryGetValue(key, out value)) {
                        value.Add(line);
                    }
                    else {
                        value = new List<string>();
                        value.Add(line);
                        sortedList.Add(key, value);
                    }

                }
            }

            return sortedList;
        }

    }
}

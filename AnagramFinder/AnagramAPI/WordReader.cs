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
                    string key = Alphabetise(line.ToLower());
                    List<string> value;

                    //Check if key already exists
                    if (sortedList.TryGetValue(key, out value)) {
                        //Check if word already exists, if so do nothing
                        //if(!value.Contains(line, StringComparer.OrdinalIgnoreCase)){
                        //Faster LINQ Check
                        if (!value.Any(str => str.Equals(line, StringComparison.OrdinalIgnoreCase))) {
                            value.Add(line);
                        }
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
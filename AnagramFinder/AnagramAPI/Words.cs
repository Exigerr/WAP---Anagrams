using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramAPI {
    public class Words {

        public string Alphabetise(string word) {
            //Converts string to array, allowing usage of the sort function - automatically re-arranging it into aplhabetical order
            char[] a = word.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }
    }
}

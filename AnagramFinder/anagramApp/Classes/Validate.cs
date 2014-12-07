using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace anagramApp.Classes {
    public class Validate {

        private bool _valid = true;
        private List<Field> _fields = new List<Field>();


        public void AddField(string field, string msg, bool valid) {
            if (!valid) { 
                _fields.Add(new Field(field, msg, valid));
                _valid = false;
            }
        }


        public bool AllValid() {
            return _valid;
        }

        public void DisplayErrors(Action<string,string>AddErrorMsg) {
            for (int i = 0; i < _fields.Count; i++) {
                Console.Write(_fields.Count);
                AddErrorMsg.Invoke(_fields[i].GetName(), _fields[i].GetMsg());

            }
        }
    }
}
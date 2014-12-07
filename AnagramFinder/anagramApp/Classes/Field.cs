using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace anagramApp.Classes {
    public class Field {
        private string _name;
        private string _msg;
        private bool _valid;

        public Field(string name, string msg, bool valid) {
            _name = name;
            _msg = msg;
            _valid = valid;
        }

        public string GetName() {
            return _name;
        }

        public bool GetValid() {
            return _valid;
        }

        public string GetMsg() {
            return _msg;
        }

    }
}
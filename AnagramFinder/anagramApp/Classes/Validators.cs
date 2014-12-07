using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace anagramApp.Classes {
    public class Validators {

        private string _emailRegEx = @"^([A-Za-z0-9\-\+\!\#\&\%\$\*\/\=\?\^_\{\|\}\`\~\''.]+)*@([A-Za-z0-9-]+)*(\.[A-Za-z]{2,4}){1,2}$";
        private string _passwordRegex = @"^[A-Za-z0-9\-\+_]{1,25}$";
        private string _nameRegex = @"^[A-Za-z][A-Za-z\'\ ]{1,25}$";

        //Check that Input value is empty and not required, therefore no need to check other validation
        private bool EmptyAndRequired(string value, bool required) {
            if (!this.NotEmpty(value) && required == false) {
                return true;
            }
            return false;
        }

        public bool IsInt(string num, bool required = false){
            if (EmptyAndRequired(num, required)) {
                return true;
            }

            int number;
            if (Int32.TryParse(num, out number)) {
                return true;
            }
            return false;
        }

        public bool IsEmail(string email, bool required = false) {
            if (EmptyAndRequired(email, required)) {
                return true;
            }
            return Regex.IsMatch(email, _emailRegEx);
        }

        public bool NotEmpty(string value){
            if(value != "" || value != null){
                return true;
            }
            return false;
        }

        public bool IsPassword(string pass, bool required = false) {
            if (EmptyAndRequired(pass, required)) {
                return true;
            }
            return Regex.IsMatch(pass, _passwordRegex);
        }

        public bool IsName(string name, bool required = false) {
            if (EmptyAndRequired(name, required)) {
                return true;
            }
            return Regex.IsMatch(name, _nameRegex);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.Data;
using WebMatrix.WebData;

namespace anagramApp.Classes {
    public class UserHelper 
    {

        public bool CreateUser(string email, string password, string userFirstname, string userLastname) {
            var user = new { firstname = userFirstname, lastname = userLastname };

            try {
                WebSecurity.CreateUserAndAccount(email, password, user);
                WebSecurity.Login(email, password);
                return true;
            }
            catch (MembershipCreateUserException ex) {
                return false;
            }
        }
        
        public bool Login(string email, string password) {
            return WebSecurity.Login(email, password);

        }

    }
}
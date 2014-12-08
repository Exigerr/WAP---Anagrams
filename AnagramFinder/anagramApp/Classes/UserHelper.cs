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

        public void AddUserWord(Database db, string userSearch) {
            //"INSERT INTO Anagrams (anagram) SELECT @param0 WHERE NOT EXISTS (SELECT anagram FROM Anagrams WHERE anagram=@param0)"
            string getId = "SELECT Id FROM Anagrams WHERE anagram = @param0";
            string updateQuery = "INSERT INTO UserSearches (userId, anagramId) SELECT @param0, @param1 WHERE NOT EXISTS (SELECT userId, anagramId FROM UserSearches WHERE userId = @param0 AND anagramId = @param1)";
            var result = db.QueryValue(getId, userSearch);
            int id = result.Id;
            db.Execute(updateQuery, WebSecurity.CurrentUserId, id);
        }

    }
}
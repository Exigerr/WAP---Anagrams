using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using anagramApp.Classes;
namespace UnitTests {
    [TestClass]
    public class ValidationEmail {

        private Validators _valid = new Validators();

        [TestInitialize]
        public void SetUp() {
        }

        [TestMethod]
        public void IsValidEmail() {
            Assert.IsTrue(_valid.IsEmail("test@testmail.co.uk"));
        }

        [TestMethod]
        public void IsValidEmail_Symbols() {
            Assert.IsTrue(_valid.IsEmail("test-+cheese@testmail.co.uk"));
        }

        [TestMethod]
        public void IsValidEmail_LongDomain() {
            Assert.IsTrue(_valid.IsEmail("test@testmail.photography"));
        }

        [TestMethod]
        public void IsInValidEmail() {
            Assert.IsFalse(_valid.IsEmail("testtestmail.com"));
        }
    }
}

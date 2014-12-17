using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using anagramApp.Classes;

namespace UnitTests {
    [TestClass]
    public class ValidationName {

        private Validators _valid = new Validators();

        [TestMethod]
        public void IsValidName() {
            Assert.IsTrue(_valid.IsName("Fred"));
        }

        [TestMethod]
        public void IsValidName_Apostrophe() {
            Assert.IsTrue(_valid.IsName("O'Reilly"));
        }

        [TestMethod]
        public void IsInValidName_Symbols() {
            Assert.IsFalse(_valid.IsName("Leet#Haxor"));
        }

        [TestMethod]
        public void IsInValidName_Numbers() {
            Assert.IsFalse(_valid.IsName("Name123"));
        }
    }
}

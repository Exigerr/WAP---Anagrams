using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using anagramApp.Classes;

namespace UnitTests {
    [TestClass]
    public class ValidationPassword {
        private Validators _valid = new Validators();

        [TestMethod]
        public void IsValidPass() {
            Assert.IsTrue(_valid.IsPassword("password123"));
        }

        [TestMethod]
        public void IsInValidPass() {
            Assert.IsFalse(_valid.IsPassword("¬!RandomStuff/"));
        }

        [TestMethod]
        public void IsInValidPass_Blank() {
            Assert.IsFalse(_valid.IsPassword(" "));
        }
    }
}

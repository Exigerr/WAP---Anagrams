using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using anagramApp.Classes;

namespace UnitTests {
    [TestClass]
    public class Validates {
        private Validate _validate = new Validate();
        private Validators _valid = new Validators();

        [TestMethod]
        public void AllValidatorsValid() {
            _validate.AddField("email", "msg", _valid.IsEmail("test@testmail.com", true));
            _validate.AddField("pass", "msg", _valid.IsPassword("cheese1", true));
            _validate.AddField("name", "msg", _valid.IsName("bob", true));

            Assert.IsTrue(_validate.AllValid());
        }

        [TestMethod]
        public void InValid() {
            _validate.AddField("email", "msg", _valid.IsEmail("test@testmail.com", true));
            _validate.AddField("pass", "msg", _valid.IsPassword("cheese1", true));
            _validate.AddField("name", "msg", _valid.IsName("bob", true));
            _validate.AddField("email", "msg", _valid.IsEmail("test@testmail@.com", true));
            _validate.AddField("pass", "msg", _valid.IsPassword(" ", true));
            _validate.AddField("name", "msg", _valid.IsName("!¬Haxor", true));

            Assert.IsFalse(_validate.AllValid());
        }

        [TestMethod]
        public void Valid_NotRequired() {
            _validate.AddField("email", "msg", _valid.IsEmail("test@testmail.com", true));
            _validate.AddField("pass", "msg", _valid.IsPassword("cheese1", true));
            _validate.AddField("name", "msg", _valid.IsName("bob", true));
            //Empty field which isn't required
            _validate.AddField("email2", "msg", _valid.IsEmail("", false));

            Assert.IsTrue(_validate.AllValid());
        }

        [TestMethod]
        public void InValid_NotRequired() {
            _validate.AddField("email", "msg", _valid.IsEmail("test@testmail.com", true));
            _validate.AddField("pass", "msg", _valid.IsPassword("cheese1", true));
            _validate.AddField("name", "msg", _valid.IsName("bob", true));
            //Empty field which isn't required
            _validate.AddField("email2", "msg", _valid.IsEmail("test@test@mail.com", false));

            Assert.IsFalse(_validate.AllValid());
        }
    }
}

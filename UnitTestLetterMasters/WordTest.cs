using LetterMasters.BL;
using LetterMasters.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLetterMasters
{
    [TestClass]
    public class WordTest
    {
        WordController _controller;
        IValidateWord _service;
        public WordTest()
        {
            _service = new ValidateWord();
            _controller = new WordController(_service);
        }

        [TestMethod]
        public void Get_WhenCalled_Returns_A_Valid_Word()
        {
            // Act
            var validWord = _controller.Get("test");

            // Assert
            Assert.AreEqual(true, validWord);
        }

        [TestMethod]
        public void Get_WhenCalled_Contains_spaces_Returns_An_Invalid_Word()
        {
            // Act
            var invalidWord = _controller.Get("test one two");

            // Assert
            Assert.AreEqual(false, invalidWord);
        }

        [TestMethod]
        public void Get_WhenCalled_Contains_Numbers_Returns_An_Invalid_Word()
        {
            // Act
            var invalidWord = _controller.Get("test123");

            // Assert
            Assert.AreEqual(false, invalidWord);
        }
        [TestMethod]
        public void Get_WhenCalled_Contains_Special_Characters_Returns_An_Invalid_Word()
        {
            // Act
            var invalidWord = _controller.Get("test%");

            // Assert
            Assert.AreEqual(false, invalidWord);
        }
    }
}

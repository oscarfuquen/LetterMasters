using System.Threading.Tasks;
using FuntionalTestLetterMasters.Helpers;
using LetterMasters.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FuntionalTestLetterMasters
{
    [TestClass]
    public class WordTest
    {
        private string requetAPI => "api/word/";
        private string requestTokenAPI => "api/token/";
        [TestMethod]
        public void WhenCalled_Returns_Un_Authorized()
        {
            var response = Task.Run(()=> Helper.getRequest<int>($"{requetAPI}test", string.Empty)).Result;
            Assert.AreEqual(401, response);
        }


        [TestMethod]
        public void WhenCalled_Returns_A_Valid_Word()
        {
            var token = Helper.postRequest(requestTokenAPI);
            var response = Task.Run(() => Helper.getRequest<Word>($"{requetAPI}test", token)).Result;
            Assert.AreEqual(true, response.IsAValidWord);
        }

        [TestMethod]
        public void WhenCalled_Contains_spaces_Returns_An_Invalid_Word()
        {
            var token = Helper.postRequest(requestTokenAPI);
            var response = Task.Run(() => Helper.getRequest<Word>($"{requetAPI}test one two", token)).Result;
            Assert.AreEqual(false, response.IsAValidWord);
        }

        [TestMethod]
        public void WhenCalled_Contains_Numbers_Returns_An_Invalid_Word()
        {
            var token = Helper.postRequest(requestTokenAPI);
            var response = Task.Run(() => Helper.getRequest<Word>($"{requetAPI}test123", token)).Result;
            Assert.AreEqual(false, response.IsAValidWord);
        }

        [TestMethod]
        public void WhenCalled_Contains_Special_Characters_Returns_An_Invalid_Word()
        {
            var token = Helper.postRequest(requestTokenAPI);
            var response = Task.Run(() => Helper.getRequest<Word>($"{requetAPI}test%", token)).Result;
            Assert.AreEqual(false, response.IsAValidWord);
        }
    }
}

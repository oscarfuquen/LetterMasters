using System.IdentityModel.Tokens.Jwt;
using LetterMasters.BL;
using LetterMasters.Controllers;
using LetterMasters.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Claims;
using NSubstitute;
using System.Collections.Generic;
using FuntionalTestLetterMasters.Model;
using Newtonsoft.Json;

namespace UnitTestLetterMasters
{
    [TestClass]
    public class TokenTest
    {
        TokenController _controller;
        ISecurityToken _service;
        public TokenTest()
        {
            _service = new SecurityToken();
            _controller = new TokenController(_service);
        }

        [TestMethod]
        public void Post_WhenCalled_Returns_A_Token()
        {
            var userModel = new UserRegisterAuthenticate
            {
                user = "Test",
                password = "TestPassword"
            };
            const string tokenValue = "validToken";
            var mockSecurityToken = Substitute.For<ISecurityToken>();
            mockSecurityToken.GetJwtSecurityToken().Returns(tokenValue);
            var tokenController = new TokenController(mockSecurityToken);
            // Act
            var token = tokenController.Post(userModel).Result;
            var objectResult = token as Microsoft.AspNetCore.Mvc.ObjectResult;

            // Assert
            var assertToken = "{ token = " + tokenValue + " }";
            Assert.AreEqual(assertToken, objectResult.Value.ToString());
            Assert.AreEqual(200, objectResult.StatusCode);
        }

        [TestMethod]
        public void Post_WhenCalled_Returns_Bad_Request()
        {
            var tokenController = _controller.Post(new UserRegisterAuthenticate()).Result;
            var statusResult = (tokenController as Microsoft.AspNetCore.Mvc.StatusCodeResult).StatusCode;
            Assert.AreEqual(400, statusResult);
        }

        [TestMethod]
        public void Post_WhenCalled_Returns_Un_Authorized()
        {
            var userModel = new UserRegisterAuthenticate
            {
                user = "Test1",
                password = "TestPassword"
            };
            var tokenController = _controller.Post(userModel).Result;
            var statusResult = (tokenController as Microsoft.AspNetCore.Mvc.StatusCodeResult).StatusCode;
            Assert.AreEqual(401, statusResult);
        }
    }
}

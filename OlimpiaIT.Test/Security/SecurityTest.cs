using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OlimpiaIT.API.Controllers;
using OlimpiaIT.API.Services.Concrete;
using OlimpiaIT.API.Services.Interfaces;
using OlimpiaIT.Entidades.Concrete.Login;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OlimpiaIT.Test.Security
{
    public class SecurityTest
    {
        SecurityController _controller;
        ISecurityService _service;

        public SecurityTest()
        {
            _service = new SecurityService();
            _controller = new SecurityController(_service);
        }

        [Test]
        public async Task Login_ReturnOK()
        {
            var result = await _controller.Login(new Login() { Username = "olimpiait", Password = "Temporal.2021" });
            var status = result as ObjectResult;

            Assert.AreEqual(200, status.StatusCode);
        }

        [Test]
        public async Task Login_ReturnUnauthorized()
        {
            var result = await _controller.Login(new Login() { Username = "NoExisto", Password = "NoExisto" });
            var status = result as UnauthorizedResult;

            Assert.AreEqual(401, status.StatusCode);
        }
    }
}

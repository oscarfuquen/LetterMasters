using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LetterMasters.BL;
using LetterMasters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LetterMasters.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly ISecurityToken _securityToken;
        public TokenController(ISecurityToken securityToken)
        {
            _securityToken = securityToken;
        }

        // GET api/token
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRegisterAuthenticate model)
        {
            if (String.IsNullOrEmpty(model.user) || String.IsNullOrEmpty(model.password))
            {
                return BadRequest();
            }

            if (model.user != "Test" || model.password != "TestPassword")
            {
                return Unauthorized();
            }

            var JWTToken = await _securityToken.GetJwtSecurityToken();
            return Ok(new
            {
                token = JWTToken
            });
        }
    }
}

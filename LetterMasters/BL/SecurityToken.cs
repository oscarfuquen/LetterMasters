using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using LetterMasters.Helpers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace LetterMasters.BL
{
    public class SecurityToken : ISecurityToken
    {
        public async Task<string> GetJwtSecurityToken()
        {
            var settings = ConfigurationHelper.GetConfig();
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings["AppConfiguration:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: settings["AppConfiguration:SiteUrl"],
                audience: settings["AppConfiguration:SiteUrl"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}

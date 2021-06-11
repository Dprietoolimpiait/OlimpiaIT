using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using OlimpiaIT.Utilidades;

namespace OlimpiaIT.API.Security
{
    public class JWTManager
    {
        public static string GenerateTokenJWT(Guid userGuid, string prmUsername)
        {
            string key = Configuration.GetSectionConfiguration("Jwt", "Key");
            string issuer = Configuration.GetSectionConfiguration("Jwt", "Issuer");
            string audience = Configuration.GetSectionConfiguration("Jwt", "Audience");
            string expiration = Configuration.GetSectionConfiguration("Jwt", "ExpirationMinutes");

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sid, userGuid.ToString()),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.GivenName, prmUsername),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(issuer: issuer,
                audience: audience,
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(expiration)),
                signingCredentials: credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodetoken;
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentProject
{
    public class JwtCreater
    {
        public const string SECRET_KEY = "superSecretKey@345";

        public JwtCreater(string email, string role)
        {
            Email = email;
            Role = role;
        }

        public string GetJwt()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:44334",
                audience: "http://localhost:44334",
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, Email), 
                    new Claim(ClaimTypes.Role, Role)
                },
                expires: DateTime.Now.AddMinutes(99900),
                signingCredentials: signinCredentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        private string Role { get; }
        private string Email { get; }

    }
}
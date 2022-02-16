using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JWTPractice
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly string _jwtKey;
        public JWTAuthenticationManager(string jwtKey)
        {
            _jwtKey = jwtKey;
        }
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            {"usr1", "pwd1" },
            {"usr2", "pwd2" }
        };

        public string Authenticate(string userName, string password)
        {
            //Bir kullanıcı var mı
            if (!users.Any(x => x.Key == userName && x.Value == password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

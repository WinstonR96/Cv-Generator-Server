using Cv_Generator_Server.Controllers;
using Cv_Generator_Server.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Services
{
    public  class AuthService
    {

        public static User Authenticate(LoginRequest data)
        {
            if (data.email.Equals("wijurost@gmail.com"))
            {
                return new User
                {
                    Username = "Winston",
                    Email = "wijurost@gmail.com",
                    UserId = 1
                };
            }

            return null;
        }

        public static string GenerateToken(User user, string secretKey)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Creamos los claims (pertenencias, características) del usuario
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())          
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);
            var encodeToken = tokenHandler.WriteToken(createdToken);

            return encodeToken;
        }
    }
}

using Cv_Generator_Server.Controllers;
using Cv_Generator_Server.Helpers;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Request;
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
    /// <summary>
    /// Servicio para resolver request relacionados a la autenticacion
    /// </summary>
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">DbContext</param>
        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Metodo para realizar la autenticacion del usuario
        /// </summary>
        /// <param name="data">Datos para hacer el login [email][password]</param>
        /// <returns>retorna el usuario y token jwt, sino el mensaje de error</returns>
        public User Authenticate(LoginRequestDTO data)
        {
            var user = _context.users.Single(x => x.Email == data.email);
            if (user == null)
                throw new Exception("Usuario no existe");
            if (user.Password != Utils.GetSHA256(data.password))
                throw new Exception("Contraseña Erronea");
            return user;
        }

        /// <summary>
        /// Permite generar el token JWT
        /// </summary>
        /// <param name="user">Usuario que intenta loguear</param>
        /// <param name="secretKey">Clave secreta</param>
        /// <returns>retorna el token JWT</returns>
        public string GenerateToken(User user, string secretKey)
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
            return tokenHandler.WriteToken(createdToken);
        }

        /// <summary>
        /// Permite cambiar la contraseña del usuario logueado
        /// </summary>
        /// <param name="data">datos para cambiar la contraseña[UserId][Password]</param>
        public void ChangePassword(UserPassDTO data)
        {
            var userOriginal = _context.users.Single(x => x.UserId == data.UserId);
            userOriginal.Password = Utils.GetSHA256(data.Password);
            if (userOriginal == null)
                throw new Exception("Usuario no encontrado");
            
            _context.Update(userOriginal);
            _context.SaveChanges();
                
        }

    }
}

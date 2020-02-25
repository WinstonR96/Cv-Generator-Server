using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cv_Generator_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Cv_Generator_Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBodyAttribute] LoginRequest data)
        {
            // Tu código para validar que el usuario ingresado es válido
            // Asumamos que tenemos un usuario válido
            var user = AuthService.Authenticate(data);

            if (user == null)
            {
                return NotFound();
            }

            var secretKey = _configuration.GetValue<string>("SecretKey");

            var token = AuthService.GenerateToken(user, secretKey);
            
            return Ok(token);

            //tokenHandler.WriteToken(createdToken);
        }
    }
}
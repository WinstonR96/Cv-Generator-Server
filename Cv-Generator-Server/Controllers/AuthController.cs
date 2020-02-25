using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Response;
using Cv_Generator_Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Cv_Generator_Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration, IAuthService authService)
        {
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] LoginDTO data)
        {
            // Tu código para validar que el usuario ingresado es válido
            try
            {
                var user = _authService.Authenticate(data);
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var token = _authService.GenerateToken(user, secretKey);
                return Ok(new ResponseDTO()
                {
                    type = "I",
                    value = token,
                    obj = user
                });
            }
            catch(Exception ex)
            {
                return Ok(new ResponseDTO()
                {
                    type = "E",
                    value = ex.Message,
                    obj = data
                });
            }
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult ChangePassword([FromBody] UserPassDTO data)
        {
            // Tu código para validar que el usuario ingresado es válido
            try
            {
                _authService.ChangePassword(data);
                return Ok(new ResponseDTO()
                {
                    type = "I",
                    value = "Contraseña cambiada",
                    obj = data
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO()
                {
                    type = "E",
                    value = ex.Message,
                    obj = data
                });
            }
        }
    }
}
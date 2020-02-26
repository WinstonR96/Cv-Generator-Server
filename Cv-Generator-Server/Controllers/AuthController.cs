using System;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Cv_Generator_Server.Controllers
{
    /// <summary>
    /// Controlador que permite gestionar la sesion del usuario
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

       
        /// <summary>
        /// constructor con la inyeccion de dependencia de los servicios necesarios
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="authService"></param>
        public AuthController(ILogger<AuthController> logger, IConfiguration configuration, IAuthService authService)
        {
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
        }

        /// <summary>
        /// Metodo para realizar login y generar token
        /// </summary>
        /// <param name="data">Informacion para solicitar el login [email] [password]</param>
        /// <returns>Retorna datos del usuario asi como el token JWT</returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] LoginRequestDTO data)
        {
            // Tu código para validar que el usuario ingresado es válido
            try
            {
                var user = _authService.Authenticate(data);
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var token = _authService.GenerateToken(user, secretKey);
                return Ok(new LoginResponseDTO()
                {
                    data = new {user.UserId, user.Email, user.Username, token}
                });
            }
            catch(Exception ex)
            {
                return Ok(new ResponseDTO()
                {
                    type = "E",
                    message = ex.Message
                });
            }
        }

        /// <summary>
        /// Permite cambiar la contraseña del usuario logueado
        /// </summary>
        /// <param name="data">Informacion para cambiar la contraseña[UserId] [Password]</param>
        /// <returns>retorna mensaje de exito o mensaje de error</returns>
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public IActionResult ChangePassword([FromBody] UserPassDTO data)
        {
            // Tu código para validar que el usuario ingresado es válido
            try
            {
                _authService.ChangePassword(data);
                return Ok(new ResponseDTO()
                {
                    type = "I",
                    message = "Contraseña cambiada"
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO()
                {
                    type = "E",
                    message = ex.Message
                });
            }
        }
    }
}
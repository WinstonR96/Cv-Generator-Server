using Cv_Generator_Server.Helpers;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Controllers
{
    /// <summary>
    /// Controlador del modelo User
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;


        /// <summary>
        /// Constructor con inyeccion de dependencias
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="userService"></param>
        public UserController(ILogger<UserController> logger, IConfiguration configuration, IUserService userService)
        {
            _logger = logger;
            _configuration = configuration;
            _userService = userService;
        }

        /// <summary>
        /// Obtener todos los usuarios
        /// </summary>
        /// <returns>retorna un listado de usuarios</returns>
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            var user = _userService.GetUsers();
            return user;
        }
        
        /// <summary>
        /// Obtener un usuario por id
        /// </summary>
        /// <param name="id">Id del usuario a obtener</param>
        /// <returns>Retorna un usuario por el id especificado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();
            return user;
            
        }

        /// <summary>
        /// Agregar nuevo usuario
        /// </summary>
        /// <param name="data">Informacion del nuevo usuario</param>
        /// <returns>Si es exitoso retorna el nuevo usuario, sino retorna el error</returns>
        [HttpPost]
        public IActionResult Add([FromBody] User data)
        {
            if (data == null)
                return BadRequest();

            data.Password = Utils.GetSHA256(data.Password);
            try
            {
                _userService.Add(data);
                return CreatedAtAction(nameof(GetUser), new { id = data.UserId }, data);
            }catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        /// <summary>
        /// Actualizar un usuario, por el momento solo se puede actualizar la foto
        /// </summary>
        /// <param name="data">Datos del usuario a modificar [UserId] y [Photo]</param>
        /// <returns>Retorna el usuario actualoizado sino retorna el error</returns>
        [HttpPut]
        public IActionResult Update([FromBody] UserPhotoDTO data)
        {
            if (data == null)
                return BadRequest();

            _userService.Update(data);
            return CreatedAtAction(nameof(GetUser), new { id = data.UserId }, data);
        }
    }
}

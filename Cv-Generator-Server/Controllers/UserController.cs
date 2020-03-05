using Cv_Generator_Server.Helpers;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Request;
using Cv_Generator_Server.Models.DTOs.Response;
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
            return _userService.GetUsers();
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
            return user == null ? NotFound() : (ActionResult<User>)user;
        }

        /// <summary>
        /// Agregar nuevo usuario
        /// </summary>
        /// <param name="data">Informacion del nuevo usuario</param>
        /// <returns>Si es exitoso retorna el nuevo usuario, sino retorna el error</returns>
        [HttpPost]
        public IActionResult Add([FromBody] UserAddDTO data)
        {
            if (data == null)
                return BadRequest();

            try
            {
                var user = _userService.Add(data);
                return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, data);
            }catch(Exception ex)
            {
                return Ok(new ResponseDTO()
                {
                    message = ex.Message,
                    type = "E"
                });
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

        /// <summary>
        /// elimina un usuario
        /// </summary>
        /// <param name="id">id del usuario a eliminar</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok(new ResponseDTO()
                {
                    type = "I",
                    message = "Eliminado sastifactoriamente"
                });
            }catch(Exception ex)
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

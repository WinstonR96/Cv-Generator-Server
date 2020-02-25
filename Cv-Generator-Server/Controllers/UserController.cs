using Cv_Generator_Server.Helpers;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, IUserService userService)
        {
            _logger = logger;
            _configuration = configuration;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            var user = _userService.GetUsers();
            return user;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.Get(id);
            if (user == null)
                return NotFound();
            return user;
            
        }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Request;
using Cv_Generator_Server.Models.DTOs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Cv_Generator_Server.Controllers
{
    /// <summary>
    /// Controlador del modelo Academic
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AcademicController : ControllerBase
    {
        private readonly ILogger<AcademicController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IAcademicService _academicService;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="configuration"></param>
        /// <param name="academicService"></param>
        public AcademicController(ILogger<AcademicController> logger, IConfiguration configuration, IAcademicService academicService)
        {
            _logger = logger;
            _configuration = configuration;
            _academicService = academicService;
        }

        /// <summary>
        /// Obtiene todos los datos academico
        /// </summary>
        /// <returns>retorna un listado de datos academico</returns>
        [HttpGet]
        public ActionResult<List<ResponseAcademicDTO>> GetAcademics()
        {
            return _academicService.GetAcademicsData();
        }

        /// <summary>
        /// Obtiene un dato academico
        /// </summary>
        /// <param name="id">id del dato</param>
        /// <returns>retorna el dato academico solicitado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseAcademicDTO>> GetAcademic(int id)
        {
            var academic = await _academicService.Get(id);
            return academic == null ? NotFound() : (ActionResult<ResponseAcademicDTO>)academic;
        }

        /// <summary>
        /// Agrega un dato academico
        /// </summary>
        /// <param name="academic">informacion de datos academico</param>
        [HttpPost]
        public ActionResult Add([FromBody] AcademicAddDTO academic)
        {
            if (academic == null)
                return BadRequest();
            try
            {
                var data = _academicService.Add(academic);
                return CreatedAtAction(nameof(GetAcademic), new { id = data.AcademicId }, academic);
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO()
                {
                    message = ex.Message,
                    type = "E"
                });
            }
        }

        /// <summary>
        /// Actualiza un dato academico
        /// </summary>
        /// <param name="data">informacion del datos academico a actualizar</param>
        [HttpPut]
        public IActionResult Update([FromBody] AcademicUpdateDTO data)
        {
            if (data == null)
                return BadRequest();

            _academicService.Update(data);
            return CreatedAtAction(nameof(GetAcademic), new { id = data.UserId }, data);
        }

        /// <summary>
        /// elimina un dato academico
        /// </summary>
        /// <param name="id">id del dato academico a eliminar</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _academicService.Delete(id);
                return Ok(new ResponseDTO()
                {
                    type = "I",
                    message = "Eliminado sastifactoriamente"
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
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Request;
using Cv_Generator_Server.Models.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Interfaces
{
    /// <summary>
    /// Interfaz de la clase Academic Service
    /// </summary>
    public interface IAcademicService
    {
        /// <summary>
        /// Agrega un dato academico
        /// </summary>
        /// <param name="academic">informacion de datos academico</param>
        public Academic Add(AcademicAddDTO academic);

        /// <summary>
        /// Obtiene un dato academico
        /// </summary>
        /// <param name="id">id del dato</param>
        /// <returns>retorna el dato academico solicitado</returns>
        public Task<ResponseAcademicDTO> Get(int id);

        /// <summary>
        /// Obtiene todos los datos academico
        /// </summary>
        /// <returns>retorna un listado de datos academico</returns>
        public List<ResponseAcademicDTO> GetAcademicsData();

        /// <summary>
        /// Actualiza un dato academico
        /// </summary>
        /// <param name="data">informacion del datos academico a actualizar</param>
        public void Update(AcademicUpdateDTO data);

        /// <summary>
        /// elimina un dato academico
        /// </summary>
        /// <param name="id">id del dato academico a eliminar</param>
        public void Delete(int id);
    }
}

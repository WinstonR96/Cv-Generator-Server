using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models.DTOs.Request
{
    /// <summary>
    /// DTO para request de actualizar datos academicos
    /// </summary>
    public class AcademicUpdateDTO
    {
        /// <summary>
        /// Id del curso
        /// </summary>
        public int AcademicId { get; set; }
        /// <summary>
        /// Tipo de estudio
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Institucion
        /// </summary>
        public string Institution { get; set; }
        /// <summary>
        /// Grado
        /// </summary>
        public string Degree { get; set; }
        /// <summary>
        /// Fecha Inicio
        /// </summary>
        public DateTime Start_Date { get; set; }
        /// <summary>
        /// Fecha Fin
        /// </summary>
        public DateTime End_Date { get; set; }
        /// <summary>
        /// Id usuario asociado
        /// </summary>
        public int UserId { get; set; }
    }
}

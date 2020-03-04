using System;

namespace Cv_Generator_Server.Models
{
    /// <summary>
    /// Clase academia
    /// </summary>
    public class Academic
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
        /// Usuario asociado
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// Id usuario asociado
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// State del academic
        /// </summary>
        public int State { get; set; }
    }
}

using System;

namespace Cv_Generator_Server.Models
{
    /// <summary>
    /// Clase experiencia laboral
    /// </summary>
    public class Experience_Work
    {
      
        /// <summary>
        /// Id experiencia
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Empresa
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Fecha inicio
        /// </summary>
        public DateTime Start_Date { get; set; }
        /// <summary>
        /// Fecha fin
        /// </summary>
        public DateTime End_Date { get; set; }
        /// <summary>
        /// Cargo ocupado
        /// </summary>
        public string Rol { get; set; }
        /// <summary>
        /// Descripcion del cargo
        /// </summary>
        public string Rol_Description { get; set; }
        /// <summary>
        /// Usuario asociado
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// Id del usuario asociado
        /// </summary>
        public int UserId { get; set; }
    }
}

using System.Collections.Generic;

namespace Cv_Generator_Server.Models
{
    /// <summary>
    /// Clase profesional info
    /// </summary>
    public class Profesional_Info
    {
        /// <summary>
        /// ID info
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Profesion
        /// </summary>
        public string Profesion { get; set; }
        /// <summary>
        /// Experiencia
        /// </summary>
        public string Experience { get; set; }
        /// <summary>
        /// Perfil profesional
        /// </summary>
        public string Profile { get; set; }
        /// <summary>
        /// Habilidades
        /// </summary>
        public List<Skill> Skill { get; set; }
        /// <summary>
        /// Usuario asociado
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// Id Usuario asociado
        /// </summary>
        public int UserId { get; set; }
    }
}

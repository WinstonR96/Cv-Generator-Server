using System;

namespace Cv_Generator_Server.Models
{
    /// <summary>
    /// Clase detalle del usuario
    /// </summary>
    public class DetailUser
    {
        /// <summary>
        /// Id del detalle
        /// </summary>
        public int DetailId { get; set; }
        /// <summary>
        /// Primer nombre
        /// </summary>
        public string First_Name { get; set; }
        /// <summary>
        /// Segundo nombre
        /// </summary>
        public string Second_Name { get; set; }
        /// <summary>
        /// Apellidos
        /// </summary>
        public string Lastname { get; set; }
        /// <summary>
        /// Edad
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Numero identidad
        /// </summary>
        public int Nit { get; set; }
        /// <summary>
        /// Fecha nacimiento
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Ciudad
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Nacionalidad
        /// </summary>
        public string Nationality { get; set; }
        /// <summary>
        /// Usuario asociado
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// Id usuario asociado
        /// </summary>
        public int UserId { get; set; }
    }
}

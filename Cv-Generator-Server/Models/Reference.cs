namespace Cv_Generator_Server.Models
{
    /// <summary>
    /// Clase Referencia
    /// </summary>
    public class Reference
    {
        /// <summary>
        /// Id Referencia
        /// </summary>
        public int ReferenceId { get; set; }
        /// <summary>
        /// Nombre de la referencia
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Telefono de la Referencia
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Email de la Referencia
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Usuario asociado a la Referencia
        /// </summary>
        public User user { get; set; }
        /// <summary>
        /// Id Usuario asociado a la referencia
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// State del reference
        /// </summary>
        public int State { get; set; }
    }
}

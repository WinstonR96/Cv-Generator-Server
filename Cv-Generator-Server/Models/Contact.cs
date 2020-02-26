namespace Cv_Generator_Server.Models
{
    /// <summary>
    /// Clase contacto
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Id del contacto
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        /// Tipo de contacto
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Descripcion del contacto
        /// </summary>
        public string Description { get; set; }
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

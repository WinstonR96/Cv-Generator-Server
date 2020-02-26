namespace Cv_Generator_Server.Models.DTOs.Response
{
    /// <summary>
    /// DTO para response generico
    /// </summary>
    public class ResponseDTO
    {
        /// <summary>
        /// Tipo de mensaje
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// Mensaje
        /// </summary>
        public string message { get; set; }
    }
}

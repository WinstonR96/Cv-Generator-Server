namespace Cv_Generator_Server.Models.DTOs.Request
{
    /// <summary>
    /// DTO para el login request
    /// </summary>
    public class LoginRequestDTO
    {
        /// <summary>
        /// Email del usuario a loguear
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// password del usuario a loguear
        /// </summary>
        public string password { get; set; }
    }
}

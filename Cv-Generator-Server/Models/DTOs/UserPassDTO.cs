namespace Cv_Generator_Server.Models.DTOs
{
    /// <summary>
    /// DTO para el request de cambiar contraseña
    /// </summary>
    public class UserPassDTO
    {
        /// <summary>
        /// Id del usuario a cambiar la contraseña
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Nueva contraseña
        /// </summary>
        public string Password { get; set; }

    }
}

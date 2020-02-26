namespace Cv_Generator_Server.Models.DTOs
{
    /// <summary>
    /// DTO para el request de cambiar foto
    /// </summary>
    public class UserPhotoDTO
    {
        /// <summary>
        /// Id del usuario a cambiar la contraseña
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Nueva contraseña
        /// </summary>
        public string Photo { get; set; }
    }
}

namespace Cv_Generator_Server.Models
{
    /// <summary>
    /// User Class
    /// </summary>
    public class User
    {
        
        /// <summary>
        /// ID del usuario
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Username del usuario
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Email del usuario
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password del usuario
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Token del usuario
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// State del usuario
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// Photo del usuario
        /// </summary>
        public string Photo { get; set; }
    }
}
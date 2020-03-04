using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Request;

namespace Cv_Generator_Server.Interfaces
{
    /// <summary>
    /// Interfaz para AuthService
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Metodo para realizar la autenticacion del usuario
        /// </summary>
        /// <param name="data">Datos para hacer el login [email][password]</param>
        /// <returns>retorna el usuario y token jwt, sino el mensaje de error</returns>
        public User Authenticate(LoginRequestDTO data);
        /// <summary>
        /// Permite generar el token JWT
        /// </summary>
        /// <param name="user">Usuario que intenta loguear</param>
        /// <param name="secretKey">Clave secreta</param>
        /// <returns>retorna el token JWT</returns>
        public string GenerateToken(User user, string secretKey);
        /// <summary>
        /// Permite cambiar la contraseña del usuario logueado
        /// </summary>
        /// <param name="data">datos para cambiar la contraseña[UserId][Password]</param>
        public void ChangePassword(UserPassDTO data);
    }
}

using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using Cv_Generator_Server.Models.DTOs.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Interfaces
{
    /// <summary>
    /// Interfaz de la clase UserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Agrega un usuario
        /// </summary>
        /// <param name="user">informacion del usuario</param>
        public User Add(UserAddDTO user);

        /// <summary>
        /// Obtiene un usuario
        /// </summary>
        /// <param name="id">id del usuario</param>
        /// <returns>retorna el usuario solicitado</returns>
        public Task<ResponseUserDTO> Get(int id);

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>retorna un listado de usuarios</returns>
        public List<User> GetUsers();

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="data">informacion del usuario a actualizar</param>
        public void Update(UserPhotoDTO data);

        /// <summary>
        /// elimina un usuario
        /// </summary>
        /// <param name="id">id del usuario a eliminar</param>
        public void Delete(int id);
    }
}

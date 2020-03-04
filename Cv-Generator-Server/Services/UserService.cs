using Cv_Generator_Server.Helpers;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Services
{
    /// <summary>
    /// Servicio para resolver request relacionados al usuario
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context">dbcontext</param>
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene un usuario
        /// </summary>
        /// <param name="id">id del usuario</param>
        /// <returns>retorna el usuario solicitado</returns>
        public async Task<User> Get(int id)
        {
            return await _context.users.FindAsync(id);
        }

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>retorna un listado de usuarios</returns>
        public List<User> GetUsers()
        {
            return _context.users.Where(x => x.State == 1).ToList();
        }

        /// <summary>
        /// Agrega un usuario
        /// </summary>
        /// <param name="user">informacion del usuario</param>
        public void Add(User user)
        {
            var userOriginal = _context.users.Single(x => x.Email == user.Email || x.Username == user.Username);
            if (userOriginal != null)
                throw new Exception("El usuario ya existe");

            _context.users.Add(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// elimina un usuario
        /// </summary>
        /// <param name="id">id del usuario a eliminar</param>
        public void Delete(int id)
        {
            try
            {
                var userOriginal = _context.users.Single(x => x.UserId == id);
                userOriginal.State = -1;
                _context.Update(userOriginal);
                _context.SaveChanges();
            }catch(Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="data">informacion del usuario a actualizar</param>
        public void Update(UserPhotoDTO data)
        {
            var userOriginal = _context.users.Single(x => x.UserId == data.UserId);
            userOriginal.Photo = data.Photo;
            _context.Update(userOriginal);
            _context.SaveChanges();
        }
    }
}

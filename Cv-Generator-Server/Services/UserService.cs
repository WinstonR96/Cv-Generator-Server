using Cv_Generator_Server.Helpers;
using Cv_Generator_Server.Interfaces;
using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs.Request;
using Cv_Generator_Server.Models.DTOs.Response;
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
        public async Task<ResponseUserDTO> Get(int id)
        {
            var user = await _context.users.FindAsync(id);
            return new ResponseUserDTO()
            {
                Email = user.Email,
                Photo = user.Photo,
                Username = user.Username
            };
        }

        /// <summary>
        /// Obtiene todos los usuarios
        /// </summary>
        /// <returns>retorna un listado de usuarios</returns>
        public List<ResponseUserDTO> GetUsers()
        {
            var users = _context.users.Where(x => x.State == 1).ToList();
            List<ResponseUserDTO> usersResponse = new List<ResponseUserDTO>();
            foreach(var user in users)
            {
                usersResponse.Add(new ResponseUserDTO()
                {
                    Username = user.Username,
                    Photo = user.Photo,
                    Email = user.Email
                });
            }
            return usersResponse;
        }

        /// <summary>
        /// Agrega un usuario
        /// </summary>
        /// <param name="user">informacion del usuario</param>
        public User Add(UserAddDTO user)
        {
            var userOriginal = _context.users.SingleOrDefault(x => x.Email.Equals(user.Email) || x.Username.Equals(user.Username));
            if (userOriginal != null)
                throw new Exception("El usuario ya existe");

            User newUser = new User()
            {
                Email = user.Email,
                Password = Utils.GetSHA256(user.Password),
                Photo = user.Photo,
                State = 1,
                Username = user.Username,
                Token = Utils.GetSHA256(user.Email+user.Username+user.Password)
            };
            _context.users.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        /// <summary>
        /// elimina un usuario
        /// </summary>
        /// <param name="id">id del usuario a eliminar</param>
        public void Delete(int id)
        {
            try
            {
                var userOriginal = _context.users.SingleOrDefault(x => x.UserId == id);
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
            var userOriginal = _context.users.SingleOrDefault(x => x.UserId == data.UserId);
            userOriginal.Photo = data.Photo;
            _context.Update(userOriginal);
            _context.SaveChanges();
        }
    }
}

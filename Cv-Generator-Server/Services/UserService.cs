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
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Get(int id)
        {
            return await _context.users.FindAsync(id);
        }


        public List<User> GetUsers()
        {
            return _context.users.ToList();
        }

        public void Add(User user)
        {
            var userOriginal = _context.users.Single(x => x.Email == user.Email || x.Username == user.Username);
            if (userOriginal != null)
                throw new Exception("El usuario ya existe");

            _context.users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userOriginal = _context.users.Single(x => x.UserId == id);
            userOriginal.State = -1;
            _context.Update(userOriginal);
            _context.SaveChanges();
        }        


        public void Update(UserPhotoDTO data)
        {
            var userOriginal = _context.users.Single(x => x.UserId == data.UserId);
            userOriginal.Photo = data.Photo;
            _context.Update(userOriginal);
            _context.SaveChanges();
        }
    }
}

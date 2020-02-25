using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Interfaces
{
    public interface IUserService
    {
        public void Add(User user);
        public Task<User> Get(int id);
        public List<User> GetUsers();
        public void Update(UserPhotoDTO data);
        public void Delete(int id);
    }
}

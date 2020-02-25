using Cv_Generator_Server.Models;
using Cv_Generator_Server.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Interfaces
{
    public interface IAuthService
    {
        public User Authenticate(LoginDTO data);
        public string GenerateToken(User user, string secretKey);
        public void ChangePassword(UserPassDTO data);
    }
}

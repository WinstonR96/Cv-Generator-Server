using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models.DTOs.Request
{
    public class UserAddDTO
    {
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
        /// Photo del usuario
        /// </summary>
        public string Photo { get; set; }
    }
}

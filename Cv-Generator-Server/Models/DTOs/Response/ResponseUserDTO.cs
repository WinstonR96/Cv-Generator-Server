using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models.DTOs.Response
{
    public class ResponseUserDTO
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
        /// Photo del usuario
        /// </summary>
        public string Photo { get; set; }
    }
}

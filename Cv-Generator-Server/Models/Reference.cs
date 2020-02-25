using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models
{
    public class Reference
    {
       
        public int ReferenceId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}

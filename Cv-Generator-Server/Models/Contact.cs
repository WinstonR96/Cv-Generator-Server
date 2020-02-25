using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models
{
    public class Contact
    {
        
        public int ContactId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}

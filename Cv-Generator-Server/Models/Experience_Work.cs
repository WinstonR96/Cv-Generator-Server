using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models
{
    public class Experience_Work
    {
      
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public string Rol { get; set; }
        public string Rol_Description { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models
{
    public class Profesional_Info
    {
        
        public int Id { get; set; }
        public string Profesion { get; set; }
        public string Experience { get; set; }
        public string Profile { get; set; }

        public List<Skill> Skill { get; set; }

        public User user { get; set; }
        public int UserId { get; set; }
    }
}

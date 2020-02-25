using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models
{
    public class Skill
    {
        public int SkillsId { get; set; }
        public string Description { get; set; }
        public int Percent { get; set; }
    }
}

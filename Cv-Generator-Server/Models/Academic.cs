using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models
{
    public class Academic
    {
      
        public int AcademicId { get; set; }
        public string Type { get; set; }
        public string Institution { get; set; }
        public string Degree { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime End_Date { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}

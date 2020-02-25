using System;
using System.ComponentModel.DataAnnotations;

namespace Cv_Generator_Server.Models
{
    public class DetailUser
    {
        public int DetailId { get; set; }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public int Nit { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }
        public string Nationality { get; set; }

        public User user { get; set; }
        public int UserId { get; set; }
    }
}

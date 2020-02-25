using System.ComponentModel.DataAnnotations;

namespace Cv_Generator_Server.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public int State { get; set; }
        public string Photo { get; set; }
    }
}
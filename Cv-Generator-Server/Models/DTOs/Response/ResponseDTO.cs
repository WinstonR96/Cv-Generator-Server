using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cv_Generator_Server.Models.DTOs.Response
{
    public class ResponseDTO
    {
        public string type { get; set; }
        public string value { get; set; }
        public object obj { get; set; }
    }
}

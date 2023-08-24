using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.UserDTOs
{
    public class UserDTO:BaseDTO
    {
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ActiveCode { get; set; }
        public bool IsDelete { get; set; }
    }
}

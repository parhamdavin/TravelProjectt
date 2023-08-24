using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.RoleDTOs
{
    public class RoleDTO:BaseDTO
    {
        public string Role { get; set; }
        public bool IsDelete { get; set; }
    }
}

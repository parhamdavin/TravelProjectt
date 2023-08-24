using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.RoleDTOs
{
    public class RoleItemDTO:BaseItemDTO
    {
        public string Role { get; set; }
        public bool IsDelete { get; set; }
    }
}

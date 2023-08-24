using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.RoleDTOs
{
    public interface IRoleDTO
    {
        public string Role { get; set; }
        public bool IsDelete { get; set; }
    }
}

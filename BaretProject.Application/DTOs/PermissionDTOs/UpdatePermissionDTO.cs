using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.PermissionDTOs
{
    public class UpdatePermissionDTO : BaseDTO, IPermissionDTO
    {
        public string PermissionTitle { get; set; }
    }
}

using BaretProject.Application.DTOs.KitchenDTOs.BusinessItemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.KitchenDTOs.BusinessTypeDTO
{
    internal class UpdateBusinessTypeDTO : BaseDTO, IBusinessTypeDTO
    {
        public string BTTitle { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.MenuDTOs
{
    public class MenuDTO:BaseDTO
    {
        public string MenuTitle { get; set; }
        public int KitchenId { get; set; }
    }
}

using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.MenuDTOs
{
    public class MenuItemDTO : BaseItemDTO
    {
        
        public string MenuTitle { get; set; }
        public List<Food> Foods { get; set; }
        public int FoodCount { get; set; }

    }
}

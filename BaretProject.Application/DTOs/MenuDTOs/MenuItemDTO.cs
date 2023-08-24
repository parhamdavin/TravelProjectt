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
        public int KitchenId { get; set; }
        public string MenuTitle { get; set; }
        public List<Foods> Foods { get; set; }
        public int FoodCount { get; set; }

    }
}

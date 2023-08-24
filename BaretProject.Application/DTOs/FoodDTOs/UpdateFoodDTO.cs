using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.FoodDTOs
{
    public class UpdateFoodDTO:BaseDTO,IFoodDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PreparationTime { get; set; }
        public string ImageFileName { get; set; }
    }
}

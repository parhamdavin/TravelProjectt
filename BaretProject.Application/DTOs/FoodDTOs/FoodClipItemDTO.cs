using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.FoodDTOs
{
    public class FoodClipItemDTO:BaseItemDTO
    {
        public string ClipTitle { get; set; }
        public DateTime TimeDuration { get; set; }
        public string ClipFileName { get; set; }
    }
}

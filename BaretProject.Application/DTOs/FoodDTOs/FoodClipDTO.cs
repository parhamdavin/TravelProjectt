﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.FoodDTOs
{
    public class FoodClipDTO:BaseDTO
    {
        public string ClipTitle { get; set; }
        public DateTime TimeDuration { get; set; }
        public string ClipFileName { get; set; }
    }
}

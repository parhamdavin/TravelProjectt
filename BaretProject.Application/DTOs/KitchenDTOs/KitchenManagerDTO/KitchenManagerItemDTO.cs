﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.KitchenDTOs.KitchenManagerDTO
{
    public class KitchenManagerItemDTO : BaseItemDTO
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public int NationalNumber { get; set; }
    }
}

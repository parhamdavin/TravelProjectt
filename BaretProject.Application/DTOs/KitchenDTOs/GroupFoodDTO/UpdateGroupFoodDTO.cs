﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.KitchenDTOs.GroupFoodDTO
{
    public class UpdateGroupFoodDTO : BaseDTO, IGroupFoodDTO
    {
        public string GFTitle { get; set; }
    }
}

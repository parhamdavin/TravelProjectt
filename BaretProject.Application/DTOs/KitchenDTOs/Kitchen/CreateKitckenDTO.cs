﻿using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.KitchenDTOs.Kitchen
{
    internal class CreateKitckenDTO : IKitchenDTO
    {
        public string KName { get; set; }
        public int BTID { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public KitchenStatus statusid { get; set; }

    }
}

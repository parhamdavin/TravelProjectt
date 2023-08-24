using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.KitchenDTOs.Kitchen
{
    internal class KitchenItemDTO : BaseItemDTO
    {
        public string KName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public int kitchenstatusid { get; set; }
        public KitchenStatus KitchenStatus
        {
            get => (KitchenStatus)kitchenstatusid;
            set => kitchenstatusid = (int)value;
        }
    }
}

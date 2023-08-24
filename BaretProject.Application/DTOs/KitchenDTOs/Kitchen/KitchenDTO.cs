using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaretProject.Core.Domain;
namespace BaretProject.Application.DTOs.KitchenDTOs.Kitchen
{
    public class KitchenDTO : BaseDTO
    {
        public string KName { get; set; }
        public int BTID { get; set; }
        public int CityId { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public KitchenStatus statusid { get; set; }
    }
}

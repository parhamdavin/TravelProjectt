using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.CityDTOs
{
    public class CityItemDTO:BaseItemDTO
    {
        public string Name { get; set; }
        public string Localcreate { get; set; }
        public string LocalUpdate { get; set; }
        public string provinceName { get; set; }
        public int provinceId { get; set; }
    }
}

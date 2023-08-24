using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.ProvinceDTOs
{
    public class ProvinceItemDTO: BaseItemDTO
    {
        public string Name { get; set; }
        public string LocalCreate { get; set; }
        public string LocalUpdate { get; set; }
        public List<string> Citys { get; set; }
        public List<int> CityIds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.CityDTOs
{
    public class UpdateCityDTO:BaseDTO,ICityDTO
    {
        public string Name { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs
{
    public class BaseItemDTO : BaseDTO, IDateDTO
    {
        public string CreateTime { get; set; }
        public string? UpdateTime { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreateON { get; set; }
        public DateTime? UpdateON { get; set; }
    }
}

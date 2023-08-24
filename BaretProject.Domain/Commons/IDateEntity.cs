using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Domain.Commons
{
    public interface IDateEntity
    {
        public DateTime UpdateTime { get; set; }
        public DateTime? RemoveTime { get; set; }
        public DateTime InsertTime { get; set; }
    }
}

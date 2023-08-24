using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Domain.Commons
{
    public class Entity:IEntity
    {
        public bool IsRemoved { get; set; } = false;
    }
}

using BaretProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Domain.Customer
{
    public class CustomerCity
    {
        public int CutomerId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Customers Customer { get; set; }
    }
}

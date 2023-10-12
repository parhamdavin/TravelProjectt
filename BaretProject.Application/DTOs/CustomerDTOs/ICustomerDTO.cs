using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.CustomerDTOs
{
    public interface ICustomerDTO
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Fullname
        {

            get => Name + " " + Family;

        }
        public int WalletBalance { get; set; }
        public string Address { get; set; }
    }
}

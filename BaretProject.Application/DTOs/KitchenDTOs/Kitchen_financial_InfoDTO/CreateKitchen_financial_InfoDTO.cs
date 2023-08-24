using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.DTOs.KitchenDTOs.Kitchen_financial_InfoDTO
{
    internal class CreateKitchen_financial_InfoDTO : IKitchen_financial_InfoDTO
    {
        public int AccountNumber { get; set; }
        public int CardNumber { get; set; }
        public string ShabaNumber { get; set; }
        public string BankName { get; set; }
        public string CardFileName { get; set; }
        public string BusinessLicenseFileName { get; set; }
    }
}

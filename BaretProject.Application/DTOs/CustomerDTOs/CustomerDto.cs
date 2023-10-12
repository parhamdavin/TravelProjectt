
namespace BaretProject.Application.DTOs.Customer
{
    public class CustomerDTO : BaseDTO
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

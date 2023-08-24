
namespace BaretProject.Application.DTOs.Customer
{
    public class CustomerDto : BaseItemDTO
    {
        public int UserId { get; set; }
        public int CityId { get; set; }
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

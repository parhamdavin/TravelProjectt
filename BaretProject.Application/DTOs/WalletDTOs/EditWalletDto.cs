namespace BaretProject.Application.DTOs
{
    public class EditWalletDto : BaseDTO
    {
        public bool IsPay { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}

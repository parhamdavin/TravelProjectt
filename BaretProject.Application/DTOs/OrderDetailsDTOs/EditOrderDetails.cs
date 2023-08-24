namespace BaretProject.Application.DTOs.OrderDetail
{
    public class EditOrderDetails : BaseDTO
    {
        public int OrdersId { get; set; }
        public int FoodId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}

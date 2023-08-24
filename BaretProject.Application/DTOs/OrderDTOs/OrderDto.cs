using BaretProject.Core.Domain;

namespace BaretProject.Application.DTOs.Order
{
    public class OrderDto : BaseItemDTO
    {
        public int CustomerId { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus
        {
            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;
        }
        public bool IsFinally { get; set; }
    }
}

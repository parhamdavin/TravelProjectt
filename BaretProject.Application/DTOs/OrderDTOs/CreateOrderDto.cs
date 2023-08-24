using BaretProject.Core.Domain;

namespace BaretProject.Application.DTOs.Order
{
    internal class CreateOrderDto
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

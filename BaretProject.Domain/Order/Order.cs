using System.ComponentModel.DataAnnotations;
namespace BaretProject.Core.Domain
{
    public class Order:BaseEntity
    {
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus
        {
            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;
        }
        public bool IsFinally { get; set; }

        #region  Navigation Property
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        #endregion

    }
}
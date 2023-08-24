using System.ComponentModel.DataAnnotations.Schema;
namespace BaretProject.Core.Domain
{
    public class OrderDetails:BaseEntity
    {

        public int Price { get; set; }
        public int Count { get; set; }

        #region  Navigation Property
        public virtual Order Orders { get; set; }      
        public virtual Foods Food { get; set; }
        #endregion
    }
}
using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        //public int ProvinceId { get; set; }

        #region  Navigation Property
        public virtual Province Province { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Kitchen Kitchen { get; set; }
        #endregion
    }
}

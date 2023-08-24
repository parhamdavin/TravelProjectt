using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public class Kitchen:BaseEntity
    {
        public string KName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int SendingMethod()
        {
            // To Do :
            return 1;
        }
        
        public BusinessType BT { get; set; }      
        public City City { get; set; }       
        public KitchenFinancialInfo KitchenFinancialInfo { get; set; }

        #region  Navigation Property
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<KitchenManagerRe> KitchenManagerRe { get; set; }
        public virtual ICollection<KitchenGroupFood> KitchenGroupFood { get; set; }

        #endregion
    }
}
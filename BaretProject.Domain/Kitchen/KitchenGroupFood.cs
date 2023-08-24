
namespace BaretProject.Core.Domain
{
    public class KitchenGroupFood:BaseRelation
    {
        public int KitchenId { get; set; }
        public int GroupFoodId { get; set; }

        #region  Navigation Property
        public virtual Kitchen Kitchen { get; set; }        
        public virtual GroupFood GroupFood { get; set; }
        #endregion

    }
}
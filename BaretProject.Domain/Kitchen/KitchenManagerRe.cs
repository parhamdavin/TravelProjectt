namespace BaretProject.Core.Domain
{
    public class KitchenManagerRe:BaseRelation
    {
        public int KitchenId { get; set; }
        public int ManagerId { get; set; }

        #region  Navigation Property
        public virtual Kitchen Kitchen { get; set; }       
        public virtual KitchenManager Manager { get; set; }
        #endregion
    }
}
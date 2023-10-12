namespace BaretProject.Core.Domain
{
    public class KitchenManager:BaseEntity
    {
 
        public string Name { get; set; }
        public string Family { get; set; }
        public int NationalNumber { get; set; }
        public Userr User { get; set; }

        #region  Navigation Property
        public virtual ICollection<KitchenManagerRe> KitchenManagerRe { get; set; }
        #endregion
    }
}
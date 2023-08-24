namespace BaretProject.Core.Domain
{
    public class Menu:BaseEntity
    {
        public string MenuTitle { get; set; }
        public int KitchenId { get; set; }

        #region  Navigation Property
        public virtual Kitchen Kitchen { get; set; }
        public virtual ICollection<Foods> Foods { get; set; }
      
        #endregion

    }
}
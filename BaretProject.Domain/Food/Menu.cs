namespace BaretProject.Core.Domain
{
    public class Menu:BaseEntity
    {
        public string MenuTitle { get; set; }
       

        #region  Navigation Property
        public virtual Kitchen Kitchen { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
      
        #endregion

    }
}
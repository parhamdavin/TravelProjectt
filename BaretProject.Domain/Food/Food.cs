using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public class Food:BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PreparationTime { get; set; }
        public string ImageFileName { get; set; }

        #region  Navigation Property
        public virtual Menu Menu { get; set; }
        public virtual ICollection<FoodClip> FoodClips { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        #endregion
    }
}
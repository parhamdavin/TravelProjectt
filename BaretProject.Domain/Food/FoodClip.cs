using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public class FoodClip:BaseEntity
    {

        public string ClipTitle { get; set; }
        public DateTime  TimeDuration{ get; set; }
        public string ClipFileName { get; set; }

        #region  Navigation Property
        public virtual Foods Food { get; set; }
        #endregion
    }
}
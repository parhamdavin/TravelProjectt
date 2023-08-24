
namespace BaretProject.Core.Domain
{
    public class BusinessType:BaseEntity
    {

        public string BTTitle { get; set; }

        #region  Navigation Property
        public virtual ICollection<Kitchen> Kitchen { get; set; }
        #endregion
    }
}
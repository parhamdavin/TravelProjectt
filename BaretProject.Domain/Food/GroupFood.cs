using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public class GroupFood:BaseEntity
    {

        public string GFTitle { get; set; }
        public int ParentId { get; set; }

        #region  Navigation Property
        public virtual GroupFood ParentGroup_Food { get; set; }
        public virtual ICollection<GroupFood> ChildGroup_Food { get; set; }
        public virtual ICollection<KitchenGroupFood> KitchenGroupFood { get; set; }
        #endregion
    }
}
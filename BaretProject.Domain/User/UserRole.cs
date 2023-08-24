namespace BaretProject.Core.Domain
{
    public class UserRole:BaseRelation
    {       
        public int RoleId { get; set; }
        public int UserId { get; set; }

        #region  Navigation Property
        public virtual Roles Role { get; set; }     
        public virtual User User { get; set; }
        #endregion
    }
}
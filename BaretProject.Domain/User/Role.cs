namespace BaretProject.Core.Domain
{
    public class Roles : BaseEntity
    {

        public string Role { get; set; }

        #region  Navigation Property
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        #endregion

    }
}
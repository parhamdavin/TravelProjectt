namespace BaretProject.Core.Domain
{
    public class Permission:BaseEntity
    {

        public string PermissionTitle { get; set; }

        #region  Navigation Property
        public virtual ICollection<RolePermission> RolePermission { get; set; }
        #endregion
    }
}
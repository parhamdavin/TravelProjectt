namespace BaretProject.Core.Domain
{
    public class RolePermission:BaseRelation 
    {
        public int PermissionId { get; set; }
        public int RoleId { get; set; }

        #region  Navigation Property
        public virtual Permission Permission { get; set; }       
        public virtual Roles Role { get; set; }
        #endregion
    }
}
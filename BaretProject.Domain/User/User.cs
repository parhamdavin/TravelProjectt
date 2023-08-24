namespace BaretProject.Core.Domain
{
    public class User:BaseEntity
    {

        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ActiveCode { get; set; }
        public bool IsActive { get; set; }

        #region  Navigation Property
        public virtual Customer Customer { get; set; }
        public virtual KitchenManager KitchenManager { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        #endregion

    }
}
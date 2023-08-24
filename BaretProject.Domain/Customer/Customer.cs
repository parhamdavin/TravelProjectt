using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public class Customer:BaseEntity
    {

        public string Name { get; set; }
        public string Family { get; set; }
        public string Fullname 
        {

            get=> Name + " " + Family;

        }
        public int WalletBalance { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public User User { get; set; }
        #region  Navigation Property
        public virtual ICollection<Wallet> Wallets{get;set;}
        public virtual ICollection<Order> Orders { get; set; }
        #endregion

    }
}
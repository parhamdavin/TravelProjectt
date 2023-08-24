using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public class WalletType:BaseEntity
    {

        public string Title { get; set; }

        #region  Navigation Property
        public virtual ICollection<Wallet> Wallet { get; set; }
        #endregion
    }
}
namespace BaretProject.Core.Domain
{
    public class Wallet:BaseEntity
    {
 
        public bool IsPay { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

        #region  Navigation Property
        public virtual WalletType WalletType { get; set; }   
        public virtual Customer Customer { get; set; }
        #endregion

    }
}
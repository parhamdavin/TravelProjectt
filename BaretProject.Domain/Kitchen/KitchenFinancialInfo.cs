namespace BaretProject.Core.Domain
{
    public class KitchenFinancialInfo:BaseEntity
    {
        public int AccountNumber { get; set; }
        public int CardNumber { get; set; }
        public string ShabaNumber { get; set; }
        public string BankName { get; set; }
        public string CardFileName { get; set; }
        public string BusinessLicenseFileName { get; set; }

        #region  Navigation Property
        public virtual Kitchen Kitchen { get; set; }
        #endregion
    }
}
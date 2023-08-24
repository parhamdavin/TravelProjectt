using System.ComponentModel.DataAnnotations;

namespace BaretProject.Core.Domain
{
    public class Province:BaseEntity
    {

        public string Name { get; set; }

        #region  Navigation Property
        public virtual ICollection<City> Citys { get; set; }
        #endregion
    }

}
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Infrastructure.Mapping.KItchenMap
{
    public class KitchenFinancialinfoMap:IEntityTypeConfiguration<KitchenFinancialInfo>
    {
        public void Configure(EntityTypeBuilder<KitchenFinancialInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(k => k.Kitchen).WithOne(k => k.KitchenFinancialInfo).HasForeignKey<Kitchen>(k => k.Id);

        }
    }
}

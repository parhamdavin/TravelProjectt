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
    public class KitchenMap : IEntityTypeConfiguration<Kitchen>
    {
        public void Configure(EntityTypeBuilder<Kitchen> builder)
        {
            builder.HasOne(c => c.City)
               .WithOne(c => c.Kitchen).HasForeignKey<City>(c => c.Id);
            builder.HasKey(p => p.Id);
            builder.HasOne(k => k.KitchenFinancialInfo).WithOne(k => k.Kitchen).HasForeignKey<KitchenFinancialInfo>(k => k.Id);
        }
    }
}

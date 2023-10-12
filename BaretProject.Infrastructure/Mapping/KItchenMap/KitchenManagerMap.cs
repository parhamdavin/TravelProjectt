using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Infrastructure.Mapping.KItchenMap
{
    public class KitchenManagerMap : IEntityTypeConfiguration<KitchenManager>
    {
        public void Configure(EntityTypeBuilder<KitchenManager> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(p => p.Id).UseIdentityColumn();
            builder.HasOne(u => u.User).WithOne(k => k.KitchenManager).HasForeignKey<KitchenManager>(k => k.Id);
        }
    }
}

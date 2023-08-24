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
    public class KitchenManagerReMap : IEntityTypeConfiguration<KitchenManagerRe>
    {
        public void Configure(EntityTypeBuilder<KitchenManagerRe> builder)
        {
            builder.HasKey(p => new { p.KitchenId, p.ManagerId });
        }
    }
}

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
    public class KitchenGroupFoodMap : IEntityTypeConfiguration<KitchenGroupFood>
    {
        public void Configure(EntityTypeBuilder<KitchenGroupFood> builder)
        {
            builder.HasKey(p => new { p.KitchenId, p.GroupFoodId });
        }
    }
}

using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Infrastructure.Mapping.FoodMap
{
    public class FoodClipMap : IEntityTypeConfiguration<FoodClip>
    {
        public void Configure(EntityTypeBuilder<FoodClip> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}

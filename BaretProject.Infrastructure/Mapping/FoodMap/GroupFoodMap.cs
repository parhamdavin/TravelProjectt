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
    public class GroupFoodMap : IEntityTypeConfiguration<GroupFood>
    {
        public void Configure(EntityTypeBuilder<GroupFood> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p=> p.ChildGroup_Food).WithOne(p=>p.ParentGroup_Food).HasForeignKey(p=>p.ParentId
            ).OnDelete(deleteBehavior: DeleteBehavior.NoAction);
            
        }
    }
}

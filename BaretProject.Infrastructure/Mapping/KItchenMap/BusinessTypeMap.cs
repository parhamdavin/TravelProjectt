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
    public class BusinessTypeMap : IEntityTypeConfiguration<BusinessType>
    {
        public void Configure(EntityTypeBuilder<BusinessType> builder)
        {
            //builder.Property(p => p.Id).UseIdentityColumn();
            builder.HasKey(p => p.Id);
        }
    }
}

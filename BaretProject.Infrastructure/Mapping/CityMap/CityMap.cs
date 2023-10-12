using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaretProject.Infrastructure
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {

            builder.HasOne(c => c.Customer)
               .WithOne(c => c.City).HasForeignKey<Customers>(c => c.Id);
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id).UseIdentityColumn();
            builder.HasOne(c => c.Kitchen)
               .WithOne(c => c.City).HasForeignKey<Kitchen>(c => c.Id);
        }
    }
}
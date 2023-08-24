using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaretProject.Infrastructure
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Ignore(p => p.Fullname);
            builder.Property(p => p.WalletBalance).HasColumnType("Money").IsRequired();
            builder.HasOne(c => c.City).WithOne(c => c.Customer).HasForeignKey<City>(b => b.Id);
            builder.HasOne(u => u.User).WithOne(c => c.Customer).HasForeignKey<User>(u => u.Id);

        }
    }
}
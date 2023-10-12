using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaretProject.Infrastructure
{
    public class CustomerMap : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id).UseIdentityColumn();
            builder.Ignore(p => p.Fullname);
            builder.Property(p => p.WalletBalance).HasColumnType("Money").IsRequired();
            builder.HasOne(c => c.City).WithOne(c => c.Customer).HasForeignKey<City>(b => b.Id);
            builder.HasMany(w=> w.Wallets).WithOne(c=>c.Customer).HasForeignKey(w => w.Id).IsRequired();
            builder.HasMany(w => w.Orders).WithOne(c => c.Customer).HasForeignKey(w => w.Id);
        }
    }
}
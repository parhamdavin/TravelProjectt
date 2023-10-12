using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaretProject.Infrastructure
{
    public class WalletTypeMap : IEntityTypeConfiguration<WalletType>
    {
        public void Configure(EntityTypeBuilder<WalletType> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(w => w.Wallets).WithOne(c => c.WalletType).HasForeignKey(w => w.Id).IsRequired();
            //builder.Property(p => p.Id).UseIdentityColumn();
        }
    }
}
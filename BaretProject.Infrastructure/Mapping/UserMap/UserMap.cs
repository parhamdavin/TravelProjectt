using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaretProject.Infrastructure
{
    public class UserMap : IEntityTypeConfiguration<Userr>
    {
        public void Configure(EntityTypeBuilder<Userr> builder)
        {
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasOne(c => c.Customer).WithOne(u => u.User).HasForeignKey<Customers>(c => c.Id);
            builder.HasKey(u => u.Id);
            //builder.Property(p => p.Id).UseIdentityColumn();
            builder.HasOne(k => k.KitchenManager).WithOne(k => k.User).HasForeignKey<KitchenManager>(u => u.Id);

        }
    }
} 
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaretProject.Infrastructure
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasOne(c => c.Customer).WithOne(u => u.User).HasForeignKey<Customer>(c => c.Id);
            builder.HasKey(u => u.Id);
            builder.HasOne(k => k.KitchenManager).WithOne(k => k.User).HasForeignKey<KitchenManager>(u => u.Id);

        }
    }
} 
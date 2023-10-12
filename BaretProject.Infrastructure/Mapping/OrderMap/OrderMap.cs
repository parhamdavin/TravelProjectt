using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BaretProject.Infrastructure
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //? Order
            //builder.Ignore(p => p.OrderStatus);

            //builder.HasKey(p => p.Id);
            //builder.Property(p => p.Id).UseIdentityColumn();
            //builder.HasMany(e => e.OrderDetails)
            //    .WithOne(e => e.Orders)
            //    .HasForeignKey(e => e.Id)
            //   .OnDelete(deleteBehavior: DeleteBehavior.NoAction);
        }
    }
}
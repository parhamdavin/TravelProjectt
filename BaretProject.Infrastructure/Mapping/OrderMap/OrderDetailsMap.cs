using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace BaretProject.Infrastructure
{
    public class OrderDetailsMap : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OrderDetails> builder)
        {           
            builder.Property(p => p.Price).HasColumnType("Money").IsRequired();
            builder.HasKey(p => p.Id);
        }
    }
}
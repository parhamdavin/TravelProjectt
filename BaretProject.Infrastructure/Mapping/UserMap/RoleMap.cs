using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BaretProject.Infrastructure
{
    public class RolesMap : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            // Roles

            // SeedData
            builder.HasData(new Roles { Id = 1, Role = "Admin" });
            builder.HasData(new Roles { Id = 2, Role = "Operator" });
            builder.HasData(new Roles { Id = 3, Role = "Customer" });
        }
    }
}
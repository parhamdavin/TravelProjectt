using Microsoft.EntityFrameworkCore;


namespace BaretProject.Infrastructure.Context
{
    public class SqlServerContext : DbContext, IApplicationContext
    {
        public SqlServerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
            base.OnModelCreating(Builder);
        }

    }
}

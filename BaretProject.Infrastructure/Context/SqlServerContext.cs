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
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                CleanContext();
                throw ex;
            }
        }

        private void CleanContext()
        {
            if (this.ChangeTracker.HasChanges())
            {
                var _list = this.ChangeTracker.Entries().Where(p => p.State == EntityState.Modified || p.State == EntityState.Added || p.State == EntityState.Deleted).ToList();
                foreach (var item in _list)
                {
                    item.State = EntityState.Unchanged;
                }
            }
        }
    }
}

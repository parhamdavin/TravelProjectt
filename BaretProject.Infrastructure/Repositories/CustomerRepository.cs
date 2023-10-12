using BaretProject.Application.Contracts.Repositories;
using BaretProject.Core.Domain;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace BaretProject.Infrastructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public CustomerRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region
        public virtual IQueryable<Customers> Table => Entities;
        public virtual IQueryable<Customers> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(Customers entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<Customers>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customers entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<Customers>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Customers entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Customers> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<Customers>().FindAsync(ids);
        }

        public async Task GetAllAsync(Customers entity)
        {
            var list = _context.Set<Customers>();
            await _context.SaveChangesAsync();

        }

        public Customers FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<Customers>().Find(ids);
            if (entity != null)
            {
                //NoTracking
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }
        #endregion
    }
}

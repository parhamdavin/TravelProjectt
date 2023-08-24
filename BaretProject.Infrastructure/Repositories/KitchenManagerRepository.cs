using BaretProject.Application.Contracts.Repositories;
using BaretProject.Core.Domain;
using BaretProject.Infrastructure.Context;
using BaretProject.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BaretProject.Infrastructure.Repositories
{
    
    public class KitchenManagerRepository : GenericRepository<KitchenManager>, IKitchenManagerRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public KitchenManagerRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region
        public virtual IQueryable<KitchenManager> Table => Entities;
        public virtual IQueryable<KitchenManager> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(KitchenManager entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<KitchenManager>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(KitchenManager entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<KitchenManager>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(KitchenManager entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public async Task<KitchenManager> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<KitchenManager>().FindAsync(ids);
        }

        public async Task GetAllAsync(KitchenManager entity)
        {
            var list = _context.Set<KitchenManager>();
            await _context.SaveChangesAsync();

        }

        public KitchenManager FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<KitchenManager>().Find(ids);
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

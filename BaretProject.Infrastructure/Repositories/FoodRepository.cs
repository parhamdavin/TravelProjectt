using BaretProject.Application.Contracts;
using BaretProject.Application.Contracts.Repositories;
using BaretProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using BaretProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaretProject.Domain.Commons;
using BaretProject.Infrastructure.Repository;

namespace BaretProject.Infrastructure.Repositories
{
    public class FoodRepository : GenericRepository<Foods>, IFoodRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public FoodRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion


        #region 
        public virtual IQueryable<Foods> Table => Entities;
        public virtual IQueryable<Foods> TableAsNoTracking => Entities.AsNoTracking();

        public async  Task AddAsync(Foods entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<Foods>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Foods entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public Foods FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<Foods>().Find(ids);
            if (entity != null)
            {
                //NoTracking
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<Foods> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<Foods>().FindAsync(ids);
        }

        public async Task GetAllAsync(Foods entity)
        {
            var list = _context.Set<Foods>();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Foods entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<Foods>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}

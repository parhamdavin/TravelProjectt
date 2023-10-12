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
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public FoodRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion


        #region 
        public virtual IQueryable<Food> Table => Entities;
        public virtual IQueryable<Food> TableAsNoTracking => Entities.AsNoTracking();

        public async  Task AddAsync(Food entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<Food>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Food entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public Food FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<Food>().Find(ids);
            if (entity != null)
            {
                //NoTracking
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<Food> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<Food>().FindAsync(ids);
        }

        public async Task GetAllAsync(Food entity)
        {
            var list = _context.Set<Food>();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Food entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<Food>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}

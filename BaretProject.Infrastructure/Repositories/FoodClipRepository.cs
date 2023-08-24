using BaretProject.Application.Contracts;
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
    public class FoodClipRepository:GenericRepository<FoodClip>,IFoodClipRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public FoodClipRepository (SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion


        #region 
        public virtual IQueryable<FoodClip> Table => Entities;
        public virtual IQueryable<FoodClip> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(FoodClip entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<FoodClip>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(FoodClip entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public FoodClip FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<FoodClip>().Find(ids);
            if (entity != null)
            {
                //NoTracking
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<FoodClip> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<FoodClip>().FindAsync(ids);
        }

        public async Task GetAllAsync(FoodClip entity)
        {
            var list = _context.Set<FoodClip>();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(FoodClip entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<FoodClip>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}

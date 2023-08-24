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
    public class MenuRepository:GenericRepository<Menu>,IMenuRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public MenuRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion


        #region 
        public virtual IQueryable<Menu> Table => Entities;
        public virtual IQueryable<Menu> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(Menu entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<Menu>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Menu entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public Menu FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<Menu>().Find(ids);
            if (entity != null)
            {
                //NoTracking
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<Menu> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<Menu>().FindAsync(ids);
        }

        public async Task GetAllAsync(Menu entity)
        {
            var list = _context.Set<Menu>();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Menu entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<Menu>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}

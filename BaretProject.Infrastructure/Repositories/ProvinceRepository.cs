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
    public class ProvinceRepository:GenericRepository<Province>,IProvinceRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public ProvinceRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion


        #region 
        public virtual IQueryable<Province> Table => Entities;
        public virtual IQueryable<Province> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(Province entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<Province>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Province entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public Province FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<Province>().Find(ids);
            if (entity != null)
            {
                //NoTracking
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<Province> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<Province>().FindAsync(ids);
        }

        public async Task GetAllAsync(Province entity)
        {
            var list = _context.Set<Province>();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Province entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<Province>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}

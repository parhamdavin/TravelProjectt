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
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public CityRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion


        #region 
        public virtual IQueryable<City> Table => Entities;
        public virtual IQueryable<City> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(City entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<City>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(City entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public City FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<City>().Find(ids);
            if (entity != null)
            {
                //NoTracking
                _context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<City> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<City>().FindAsync(ids);
        }

        public async Task GetAllAsync(City entity)
        {
            var list = _context.Set<City>();
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(City entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<City>().Update(entity);
            await _context.SaveChangesAsync();
        }
        #endregion

    }
}

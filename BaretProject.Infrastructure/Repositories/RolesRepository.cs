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
    public class RolesRepository : GenericRepository<Roles>, IRoleRepository
    {

        #region Field
        private readonly IApplicationContext _context;
        public RolesRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region
        public virtual IQueryable<Roles> Table => Entities;
        public virtual IQueryable<Roles> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(Roles entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<Roles>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Roles entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<Roles>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Roles entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Roles> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<Roles>().FindAsync(ids);
        }

        public async Task GetAllAsync(Roles entity)
        {
            var list = _context.Set<Roles>();
            await _context.SaveChangesAsync();

        }

        public Roles FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<Roles>().Find(ids);
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

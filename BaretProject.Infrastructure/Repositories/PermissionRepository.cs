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
    public class PermissionRepository: GenericRepository<Permission>, IPermissionRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public PermissionRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region
        public virtual IQueryable<Permission> Table => Entities;
        public virtual IQueryable<Permission> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(Permission entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<Permission>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Permission entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<Permission>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Permission entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Permission> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<Permission>().FindAsync(ids);
        }

        public async Task GetAllAsync(Permission entity)
        {
            var list = _context.Set<Permission>();
            await _context.SaveChangesAsync();

        }

        public Permission FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<Permission>().Find(ids);
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

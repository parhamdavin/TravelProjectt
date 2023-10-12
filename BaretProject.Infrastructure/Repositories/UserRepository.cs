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
    public class UserRepository : GenericRepository<Userr>, IUserRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public UserRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region
        public virtual IQueryable<Userr> Table => Entities;
        public virtual IQueryable<Userr> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(Userr entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<Userr>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Userr entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<Userr>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Userr entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public async Task<Userr> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<Userr>().FindAsync(ids);
        }

        public async Task GetAllAsync(Userr entity)
        {
            var list = _context.Set<Userr>();
            await _context.SaveChangesAsync();

        }

        public Userr FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<Userr>().Find(ids);
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

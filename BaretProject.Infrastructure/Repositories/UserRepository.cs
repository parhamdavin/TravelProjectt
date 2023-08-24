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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Field
        private readonly IApplicationContext _context;
        public UserRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        #region
        public virtual IQueryable<User> Table => Entities;
        public virtual IQueryable<User> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<User>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<User>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<User>().FindAsync(ids);
        }

        public async Task GetAllAsync(User entity)
        {
            var list = _context.Set<User>();
            await _context.SaveChangesAsync();

        }

        public User FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<User>().Find(ids);
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

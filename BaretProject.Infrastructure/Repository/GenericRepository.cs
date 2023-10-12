using BaretProject.Application.Contracts;
using BaretProject.Core.Domain;
using BaretProject.Domain.Commons;
using BaretProject.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BaretProject.Infrastructure.Repository
{
    public partial class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity: Entity
    {

        #region Fields
        private readonly IApplicationContext _context;
        public GenericRepository(IApplicationContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> entities;
        protected DbSet<TEntity> Entities
        {
            get
            {
                if (entities == null)
                    entities = _context.Set<TEntity>();
                else
                {
                    return entities;
                }

                return entities;
            }
        }
        #endregion

        #region Methods

        public virtual IQueryable<TEntity> Table => Entities;
        public virtual IQueryable<TEntity> TableAsNoTracking => Entities.AsNoTracking();

        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
             _context.Set<TEntity>().Update(entity);
            _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsRemoved = true;
            _context.SaveChangesAsync();
        }

        public async Task<TEntity> FindByIdAsync(params object[] ids)
        {
            return await _context.Set<TEntity>().FindAsync(ids);
        }

        public async Task GetAllAsync(TEntity entity)
        {
            var list = _context.Set<TEntity>();
            await _context.SaveChangesAsync();

        }

        public TEntity FindByIdAsNoTracking(params object[] ids)
        {
            var entity = _context.Set<TEntity>().Find(ids);
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


using BaretProject.Core.Domain;
using BaretProject.Domain.Commons;
using System.Data.Common;

namespace BaretProject.Application.Contracts
{
    public partial interface IGenericRepository<TEntity> where TEntity : Entity
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task GetAllAsync(TEntity entity);
        Task<TEntity> FindByIdAsync(params object[] ids);
        TEntity FindByIdAsNoTracking(params object[] ids);
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableAsNoTracking { get; }
       
    }
}
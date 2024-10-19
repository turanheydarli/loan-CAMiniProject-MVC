using System.Linq.Expressions;
using Loan.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Loan.DataAccess.Persistence.Repositories;

public interface IAsyncRepository<TEntity, TContext> where TContext : DbContext
    where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

    Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity?, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTracking = false);

    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> DeleteAsync(TEntity entity);
    Task<TEntity> DetachAsync(TEntity entity);
}
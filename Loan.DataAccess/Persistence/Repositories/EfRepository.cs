using System.Linq.Expressions;
using Loan.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Loan.DataAccess.Persistence.Repositories;

public class EfRepository<TEntity, TContext> : IRepository<TEntity, TContext>, IAsyncRepository<TEntity, TContext>
    where TEntity : BaseEntity
    where TContext : DbContext

{
    protected TContext Context { get; }

    public EfRepository(TContext context)
    {
        Context = context;
    }

    public IQueryable<TEntity?> Query()
    {
        return Context.Set<TEntity>();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public TEntity? Get(Expression<Func<TEntity?, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity?> queryable = Query();
        if (include != null) queryable = include(queryable!);

        return queryable.FirstOrDefault(predicate);
    }

    public IList<TEntity?> GetList(Expression<Func<TEntity?, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTracking = false)
    {
        IQueryable<TEntity?> queryable = Query();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (!isTracking) queryable = queryable.AsNoTracking();

        return queryable.ToList();
    }

    public TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        Context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
    {
        IQueryable<TEntity?> queryable = Query();
        if (include != null) queryable = include(queryable!);

        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity?, bool>> predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTracking = false)
    {
        IQueryable<TEntity?> queryable = Query();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (!isTracking) queryable = queryable.AsNoTracking();

        return await queryable.ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Deleted;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DetachAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Detached;
        await Context.SaveChangesAsync();
        return entity;
    }
}
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RichDomainModel.Application.Seedwork.Repositories.Seedwork;
using RichDomainModel.Rich.Seedwork;

namespace RichDomainModel.Infrastructure.Repositories.Seedwork;

/// <summary>
/// Implementation of the generic query repository
/// </summary>
public class QueryRepository(IAppDbContext context) : IQueryRepository
{
    public virtual async Task<TEntity?> GetByIdAsync<TEntity, TId>(TId id, CancellationToken cancellationToken = default) 
        where TId : notnull
        where TEntity : Entity<TId> =>
        await context.Set<TEntity>().FindAsync(id, cancellationToken);

    public virtual async Task<IReadOnlyList<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        where TEntity : class =>
        await context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);

    public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync<TEntity>(CancellationToken cancellationToken = default)
        where TEntity : class =>
        await context.Set<TEntity>().ToListAsync(cancellationToken);

    public virtual async Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) 
        where TEntity : class =>
        await context.Set<TEntity>().AnyAsync(predicate, cancellationToken);

    public virtual async Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default) 
        where TEntity : class =>
        await context.Set<TEntity>().CountAsync(predicate, cancellationToken);
}
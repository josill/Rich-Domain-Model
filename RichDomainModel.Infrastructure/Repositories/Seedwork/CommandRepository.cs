using Microsoft.EntityFrameworkCore;
using RichDomainModel.Application.Seedwork.Repositories.Seedwork;

namespace RichDomainModel.Infrastructure.Repositories.Seedwork;

/// <summary>
/// Interface for repository operations that modify data
/// </summary>
public class CommandRepository(IAppDbContext context) : ICommandRepository
{
    public virtual async Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity);

        try
        {
            await context.Set<TEntity>().AddAsync(entity, cancellationToken);
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException($"Failed to add entity of type {typeof(TEntity).Name}.", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An unexpected error occurred while adding entity of type {typeof(TEntity).Name}.", ex);
        }

        return entity;
    }

    public virtual async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entities);

        await context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    }

    public virtual Task UpdateAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity);

        context.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public virtual Task DeleteAsync<TEntity>(TEntity entity)
        where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity);

        context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public virtual Task DeleteRangeAsync<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entities);

        context.Set<TEntity>().RemoveRange(entities);
        return Task.CompletedTask;
    }
}
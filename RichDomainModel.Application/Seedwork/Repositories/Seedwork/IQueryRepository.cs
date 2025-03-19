using System.Linq.Expressions;
using RichDomainModel.Rich.Seedwork;

namespace RichDomainModel.Application.Seedwork.Repositories.Seedwork;

/// <summary>
/// Interface for repository operations that query data but don't modify it.
/// </summary>
public interface IQueryRepository
{
    /// <summary>
    /// Gets entity by its identifier
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Entity if found, otherwise null</returns>
    Task<TEntity?> GetByIdAsync<TEntity, TId>(TId id, CancellationToken cancellationToken = default)
        where TId : notnull
        where TEntity : Entity<TId>;
    
    /// <summary>
    /// Finds all entities that match the provided specification
    /// </summary>
    /// <param name="predicate">A predicate to filter entities</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Collection of matched entities</returns>
    Task<IReadOnlyList<TEntity>> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        where TEntity : class;
    
    /// <summary>
    /// Gets a collection of all entities
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Collection of all entities</returns>
    Task<IReadOnlyList<TEntity>> GetAllAsync<TEntity>(CancellationToken cancellationToken = default)
        where TEntity : class;
    
    /// <summary>
    /// Checks if any entity matches the given predicate
    /// </summary>
    /// <param name="predicate">A predicate to filter entities</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if any entity matches the predicate, otherwise false</returns>
    Task<bool> AnyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        where TEntity : class;
    
    /// <summary>
    /// Counts entities that match the provided predicate
    /// </summary>
    /// <param name="predicate">A predicate to filter entities</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Count of matching entities</returns>
    Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        where TEntity : class;
}
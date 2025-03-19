namespace RichDomainModel.Application.Seedwork.Repositories.Seedwork;

/// <summary>
/// Interface for repository operations that modify data
/// </summary>
public interface ICommandRepository
{
    /// <summary>
    /// Adds a new entity to the repository
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the asynchronous operation</returns>
    Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        where TEntity : class;
    
    /// <summary>
    /// Adds a collection of new entities to the repository
    /// </summary>
    /// <param name="entities">Entities to add</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Task representing the asynchronous operation</returns>
    Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        where TEntity : class;
    
    /// <summary>
    /// Updates an existing entity in the repository
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <returns>Task representing the asynchronous operation</returns>
    Task UpdateAsync<TEntity>(TEntity entity)
        where TEntity : class;
    
    /// <summary>
    /// Removes an entity from the repository
    /// </summary>
    /// <param name="entity">Entity to remove</param>
    /// <returns>Task representing the asynchronous operation</returns>
    Task DeleteAsync<TEntity>(TEntity entity)
        where TEntity : class;

    /// <summary>
    /// Removes a collection of entities from the repository
    /// </summary>
    /// <param name="entities">Entities to remove</param>
    /// <returns>Task representing the asynchronous operation</returns>
    Task DeleteRangeAsync<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : class;
}
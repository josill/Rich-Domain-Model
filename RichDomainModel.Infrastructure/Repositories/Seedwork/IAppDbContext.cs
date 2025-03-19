using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RichDomainModel.Infrastructure.Repositories.Seedwork.Contexts;

namespace RichDomainModel.Infrastructure.Repositories.Seedwork;

public interface IAppDbContext :
    // TODO: make these protected
    ITimeEntryContext,
    ITagContext
{
    /// <summary>
    /// Gets a DbSet instance for the given entity type
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    /// <returns>DbSet instance for the entity type</returns>
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    
    /// <summary>
    /// Gets an entry instance for the given entity
    /// </summary>
    /// <param name="entity">The entity</param>
    /// <returns>Entry instance for the entity</returns>
    EntityEntry Entry(object entity);
}
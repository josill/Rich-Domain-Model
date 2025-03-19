using RichDomainModel.Application.Seedwork.Repositories.Seedwork;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Application.Seedwork.Repositories;

public interface ITagRepository : IQueryRepository
{
    /// <summary>
    /// Retrieves a list of tags by their identifiers
    /// </summary>
    /// <param name="ids">List of tag identifiers to retrieve</param>
    /// <returns>A task that resolves to a list of matching tags</returns>
    public Task<List<Tag>> GetByIds(List<TagId> ids);
}
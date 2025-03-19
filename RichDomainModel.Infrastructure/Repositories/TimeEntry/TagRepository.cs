using Microsoft.EntityFrameworkCore;
using RichDomainModel.Application.Seedwork.Repositories;
using RichDomainModel.Infrastructure.Repositories.Seedwork;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Infrastructure.Repositories.TimeEntry;

public class TagRepository(IAppDbContext context) : QueryRepository(context), ITagRepository
{
    private readonly IAppDbContext _context = context;

    public async Task<List<Tag>> GetByIds(List<TagId> ids) =>
        await _context.Tags.Where(x => ids.Contains(x.Id)).ToListAsync();
}
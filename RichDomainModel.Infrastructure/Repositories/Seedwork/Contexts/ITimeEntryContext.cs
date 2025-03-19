using Microsoft.EntityFrameworkCore;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Infrastructure.Repositories.Seedwork.Contexts;

public interface ITimeEntryContext
{ 
    DbSet<TimeEntryAggregate> TimeEntries { get; }
}
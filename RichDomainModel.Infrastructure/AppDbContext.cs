using Microsoft.EntityFrameworkCore;
using RichDomainModel.Infrastructure.TimeEntry.Configurations;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ApplyEntityConfiguration(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private static void ApplyEntityConfiguration(ModelBuilder modelBuilder)
    {
        new TimeEntryAggregateConfiguration().Configure(modelBuilder.Entity<TimeEntryAggregate>());
    }
}
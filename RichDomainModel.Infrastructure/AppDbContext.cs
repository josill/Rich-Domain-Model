using Microsoft.EntityFrameworkCore;
using RichDomainModel.Application.Seedwork.Repositories.Seedwork;
using RichDomainModel.Infrastructure.Configurations.TimeEntry;
using RichDomainModel.Infrastructure.Repositories.Seedwork;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<TimeEntryAggregate> TimeEntries { get; init; }
    public DbSet<Tag> Tags { get; init; }
    
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
        new TagConfiguration().Configure(modelBuilder.Entity<Tag>());
    }
}
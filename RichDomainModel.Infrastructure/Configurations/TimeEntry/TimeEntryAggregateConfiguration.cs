using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Infrastructure.Configurations.TimeEntry;

internal sealed class TimeEntryAggregateConfiguration : IEntityTypeConfiguration<TimeEntryAggregate>
{
    public void Configure(EntityTypeBuilder<TimeEntryAggregate> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new TimeEntryId(value))
            .IsRequired();

        new TimeEntryDescriptionConfiguration().Configure(builder.ComplexProperty(x => x.Description));
        
        new TimeEntryTimerConfiguration().Configure(builder.ComplexProperty(x => x.Timer));

        builder.Property(x => x.IsBillable)
            .IsRequired();

        builder.HasMany(x => x.Tags)
            .WithMany(x => x.TimeEntries)
            .UsingEntity(x =>
            {
                x.ToTable("TimeEntryTags");
            });
    }
}
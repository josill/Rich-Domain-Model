using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Infrastructure.TimeEntry.Configurations;

internal sealed class TimeEntryTimerConfiguration
{
    public void Configure(ComplexPropertyBuilder<TimeEntryTimer> builder)
    {
        builder.Property(x => x.StartTime);
        builder.Property(x => x.EndTime);
    }
}
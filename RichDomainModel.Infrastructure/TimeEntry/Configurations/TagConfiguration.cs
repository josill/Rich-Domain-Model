using System.Drawing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichDomainModel.Rich.Aggregates.TimeEntry;

namespace RichDomainModel.Infrastructure.TimeEntry.Configurations;

internal sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => new TagId(value))
            .IsRequired();

        builder.Property(x => x.Name).IsRequired();
 
        builder.Property(x => x.Color)
            .HasConversion(
                color => color.ToArgb(),
                value => Color.FromArgb(value))
            .IsRequired();
        
        // No need to configure relationships because that is done on the join table configuration (TimeEntryTagConfiguration) class
    }
}
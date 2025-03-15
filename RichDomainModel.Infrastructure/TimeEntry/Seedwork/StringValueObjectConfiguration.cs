using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichDomainModel.Rich.Seedwork;

namespace RichDomainModel.Infrastructure.TimeEntry.Seedwork;

public class StringValueObjectConfiguration<T> where T : StringValueObject<T>
{
    public void Configure(ComplexPropertyBuilder<T> builder)
    {
        builder.Property(x => x.Value).IsRequired();
    }
}
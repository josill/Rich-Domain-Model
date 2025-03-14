using RichDomainModel.Rich.Seedwork;

namespace RichDomainModel.Rich.Aggregates.TimeEntry;

public record TimeEntryDescription : StringValueObject<TimeEntryDescription>
{
    private TimeEntryDescription(string value) : base(value) { }
    public static TimeEntryDescription Create(string value) => new TimeEntryDescription(value);
}
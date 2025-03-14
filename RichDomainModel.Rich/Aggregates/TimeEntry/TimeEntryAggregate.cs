using RichDomainModel.Rich.Exceptions;
using RichDomainModel.Rich.Seedwork;

namespace RichDomainModel.Rich.Aggregates.TimeEntry;

public record struct TimeEntryId(Guid Value);

/// <summary>
/// Represents a time entry
/// </summary>
public class TimeEntryAggregate : Aggregate<TimeEntryId>
{
    public TimeEntryDescription Description { get; private set; } = default!;

    public TimeEntryTimer Timer { get; private set; } = default!;
    
    public bool IsBillable { get; private set; }

    private readonly List<Tag> _tags = [];
    public IReadOnlyCollection<Tag> Tags => _tags.AsReadOnly().ToList();

    private TimeEntryAggregate() { }

    public static TimeEntryAggregate Create(TimeEntryDescription description, TimeEntryTimer timer, bool isBillable)
    {
        return new TimeEntryAggregate()
        {
            Description = description,
            Timer = timer,
            IsBillable = isBillable,
        };
    } 

    public void UpdateDescription(string description) => Description = TimeEntryDescription.Create(description);

    public void UpdateTimer(DateTime startTime, DateTime? endTime) => Timer = TimeEntryTimer.Create(startTime, endTime);

    public void AddTag(Tag tag)
    {
        if (_tags.Any(x => x.Id == tag.Id))
        {
            throw DomainException.For<TimeEntryAggregate>($"Tag with id: {tag.Id} already exists");
        }
        _tags.Add(tag);
    }
    
    public void RemoveTag(Tag tag)
    {
        var existingTag = _tags.FirstOrDefault(x => x.Id == tag.Id);
        if (existingTag == null) throw DomainException.For<TimeEntryAggregate>($"Tag with id: {tag.Id} does not exist");
        
        _tags.Remove(existingTag);
    }
}
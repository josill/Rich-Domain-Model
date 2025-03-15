using System.Drawing;
using RichDomainModel.Rich.Exceptions;
using RichDomainModel.Rich.Seedwork;

namespace RichDomainModel.Rich.Aggregates.TimeEntry;

public readonly record struct TagId(Guid Value);

/// <summary>
/// Represents a tag for the time entry
/// </summary>
public class Tag : Entity<TagId>
{
    public string Name { get; }
    
    public Color Color { get; }

    private readonly List<TimeEntryAggregate> _timeEntries = [];
    public IEnumerable<TimeEntryAggregate> TimeEntries => _timeEntries.AsReadOnly().ToList();

    private static void Validate(string name, Color color)
    {
        if (string.IsNullOrWhiteSpace(name)) throw DomainException.For<Tag>("Name can't be empty");
        if (!color.IsKnownColor) throw DomainException.For<Tag>("Color is not known");
    }
    
    private Tag(string name, Color color)
    {
        Validate(name, color);
        
        Name = name.Trim();
        Color = color;
    }

    public static Tag Create(string name, Color color) => new Tag(name, color);
}
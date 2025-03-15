using System.ComponentModel.DataAnnotations;
using System.Drawing;
using RichDomainModel.Anemic.Entities.Seedwork;

namespace RichDomainModel.Anemic.Entities.TimeEntry;

/// <summary>
/// Represents a tag for the time entry
/// </summary>
public class Tag : EntityMetadata
{
    [Required]
    public required string Name { get; set; }
    
    [Required]
    public required Color Color { get; set; }
    
    public virtual ICollection<TimeEntry> TimeEntries { get; set; } = new List<TimeEntry>();
}
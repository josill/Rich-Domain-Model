using System.ComponentModel.DataAnnotations;
using RichDomainModel.Anemic.Entities.Seedwork;

namespace RichDomainModel.Anemic.Entities.TimeEntry;

/// <summary>
/// Represents a time entry
/// </summary>
public class TimeEntry : EntityMetadata
{
    [Required]
    public required string Description { get; set; }

    [Required]
    public required DateTime StartTime { get; set; }

    public required DateTime? EndTime { get; set; }

    public int? Duration { get; set; }

    [Required]
    public required bool IsRunning { get; set; }

    [Required]
    public required bool IsBillable { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
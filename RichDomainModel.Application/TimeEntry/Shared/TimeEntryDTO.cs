namespace RichDomainModel.Application.TimeEntry.Shared;

public record TimeEntryDTO
{
    /// <summary>
    /// Time entry idenitifer
    /// </summary>
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Description of the time entry
    /// </summary>
    public required string Description { get; init; } = null!;
    
    /// <summary>
    /// Start time of the time entry
    /// </summary>
    public required DateTime StartTime { get; init; }
    
    /// <summary>
    /// End time of the time entry
    /// </summary>
    public DateTime? EndTime { get; init; }
    
    /// <summary>
    /// Is the time entry running
    /// </summary>
    public bool IsRunning { get; init; }
    
    /// <summary>
    /// Time entry duration in seconds
    /// </summary>
    public double DurationInSeconds { get; init; }
    
    /// <summary>
    /// Time entry duration in minutes
    /// </summary>
    public double DurationInMinutes { get; init; }
    
    /// <summary>
    /// Is the time entry billable
    /// </summary>
    public required bool IsBillable { get; init; }
    
    /// <summary>
    /// List of tag ids related to the time entry
    /// </summary>
    public required List<TagDTO> Tags { get; init; } = null!;
}


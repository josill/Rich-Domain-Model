using MediatR;

namespace RichDomainModel.Application.TimeEntry.Commands.CreateTimeEntry;

public record CreateTimeEntryRequest : IRequest<CreateTimeEntryResponse>
{
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
    /// Is the time entry billable
    /// </summary>
    public required bool IsBillable { get; init; }
    
    /// <summary>
    /// List of tag ids related to the time entry
    /// </summary>
    public required List<Guid> Tags { get; init; } = null!;
}
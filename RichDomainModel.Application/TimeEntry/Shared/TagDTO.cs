using System.Drawing;

namespace RichDomainModel.Application.TimeEntry.Shared;

public record TagDTO
{
    /// <summary>
    /// Tag name 
    /// </summary>
    public string Name { get; init; } = null!;
    
    /// <summary>
    /// Tag color
    /// </summary>
    public Color Color { get; init; }
}
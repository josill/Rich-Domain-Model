using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RichDomainModel.Anemic.Entities.Seedwork;

public abstract class EntityMetadata
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public required Guid Id { get; set; }
    
    [Required] 
    public required DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    public required DateTime UpdatedAt { get; set; } = DateTime.Now;
}
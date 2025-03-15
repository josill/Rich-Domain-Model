namespace RichDomainModel.Rich.Seedwork;

/// <summary>
/// Base class for domain objects that form a consistency boundary and enforce business rules
/// for their child entities.
/// </summary>
/// <typeparam name="TId">The identifier type.</typeparam>
public abstract class Aggregate<TId> : Entity<TId> where TId : notnull
{
#pragma warning disable SA1600
    protected Aggregate() {} // Protected constructor for inheriting classes to use with EF Core
#pragma warning restore SA1600

    /// <summary>
    /// Initializes a new instance of the <see cref="Aggregate{TId}"/> class.
    /// </summary>
    /// <param name="id">The identifier of the aggregate.</param>
    protected Aggregate(TId id) : base(id) {}
}
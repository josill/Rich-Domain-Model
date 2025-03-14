namespace RichDomainModel.Rich.Seedwork;

/// <summary>
/// Interface for value objects that support addition.
/// </summary>
/// <typeparam name="T">The type of the value object.</typeparam>
public interface IAddableValueObject<T> where T : ValueObject<T>
{
    /// <summary>
    /// Adds another value object to this one.
    /// </summary>
    /// <param name="other">The value object to add to this instance.</param>
    /// <returns>A new value object representing the result of the addition.</returns>
    T Add(T other);
}
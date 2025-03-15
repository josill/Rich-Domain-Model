namespace RichDomainModel.Rich.Seedwork;

/// <summary>
/// Interface for value objects that support subtraction.
/// </summary>
/// <typeparam name="T">The type of the value object.</typeparam>
public interface ISubtractableValueObject<T> where T : ValueObject<T>
{
    /// <summary>
    /// Subtracts another value object from this one.
    /// </summary>
    /// <param name="other">The value object to subtract from this instance.</param>
    /// <returns>A new value object representing the result of the subtraction.</returns>
    T Subtract(T other);
}
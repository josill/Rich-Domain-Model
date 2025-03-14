using RichDomainModel.Rich.Exceptions;

namespace RichDomainModel.Rich.Seedwork;

/// <summary>
/// Represents a base class for value objects in the domain model.
/// </summary>
/// <typeparam name="T">The type of the value object.</typeparam>
public abstract class ValueObject<T> where T : ValueObject<T>
{
    /// <summary>
    /// Determines whether two value objects are equal.
    /// </summary>
    /// <param name="left">The first value object to compare.</param>
    /// <param name="right">The second value object to compare.</param>
    /// <returns>true if the value objects are equal; otherwise, false.</returns>
    public static bool operator ==(ValueObject<T>? left, ValueObject<T>? right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two value objects are not equal.
    /// </summary>
    /// <param name="left">The first value object to compare.</param>
    /// <param name="right">The second value object to compare.</param>
    /// <returns>true if the value objects are not equal; otherwise, false.</returns>
    public static bool operator !=(ValueObject<T>? left, ValueObject<T>? right) => !(left == right);

    /// <summary>
    /// Adds two value objects together if they support addition.
    /// </summary>
    /// <param name="left">The first value object.</param>
    /// <param name="right">The second value object.</param>
    /// <returns>A new value object representing the sum of the two value objects.</returns>
    /// <exception cref="NotSupportedException">Thrown when the value objects don't support addition.</exception>
    public static T operator +(ValueObject<T> left, ValueObject<T> right)
    {
        if (left is IAddableValueObject<T> addableLeft) return addableLeft.Add((T)right);
        if (left is IArithmeticValueObject<T> arithmeticLeft) return arithmeticLeft.Add((T)right);

        throw DomainException.For<T>($"Addition is not supported for value objects of type {typeof(T).Name}");
    }

    /// <summary>
    /// Subtracts two value objects together if they support subtraction.
    /// </summary>
    /// <param name="left">The first value object.</param>
    /// <param name="right">The second value object.</param>
    /// <returns>A new value object representing the sum of the two value objects.</returns>
    /// <exception cref="NotSupportedException">Thrown when the value objects don't support addition.</exception>
    public static T operator -(ValueObject<T> left, ValueObject<T> right)
    {
        if (left is ISubtractableValueObject<T> subtractableLeft) return subtractableLeft.Subtract((T)right);
        if (left is IArithmeticValueObject<T> arithmeticLeft) return arithmeticLeft.Subtract((T)right);

        throw DomainException.For<T>($"Subtraction is not supported for value objects of type {typeof(T).Name}");
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<T>)obj;
        return GetAttributesToIncludeInEqualityCheck()
            .SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
        return GetAttributesToIncludeInEqualityCheck()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return (current * 23) + (obj?.GetHashCode() ?? 0);
                }
            });
    }

    /// <summary>
    /// Gets the components of the value object used for equality comparison.
    /// </summary>
    /// <returns>An enumerable collection of objects representing the equality components.</returns>
    protected abstract IEnumerable<object?> GetAttributesToIncludeInEqualityCheck();
}
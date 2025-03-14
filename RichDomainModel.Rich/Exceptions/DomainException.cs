namespace RichDomainModel.Rich.Exceptions;

/// <summary>
/// Represents a domain-specific exception that is associated with a particular type.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    private DomainException(string message) : base(message) { }

    /// <summary>
    /// Creates a new instance of <see cref="DomainException"/>.
    /// </summary>
    /// <typeparam name="T">The type associated with this domain exception.</typeparam>
    /// <param name="message">The error message.</param>
    /// <returns>The thrown domain exception.</returns>
    public static Exception For<T>(string message) => throw new DomainException(message);
}
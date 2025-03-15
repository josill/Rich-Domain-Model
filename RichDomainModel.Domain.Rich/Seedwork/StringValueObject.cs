using RichDomainModel.Rich.Exceptions;

namespace RichDomainModel.Rich.Seedwork;

/// <summary>
/// A generic string value object that enforces validation rules
/// </summary>
/// <typeparam name="T">The specific derived type</typeparam>
public abstract record StringValueObject<T> where T : StringValueObject<T>
{
    public string Value { get; }

    public StringValueObject(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw DomainException.For<T>($"{typeof(T).Name} value cannot be empty");
        Value = value;
    }
    
    public static implicit operator string(StringValueObject<T> valueObject) => valueObject.Value;

    public override string ToString() => Value;
}
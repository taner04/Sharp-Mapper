using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper.Attributes;

/// <summary>
///     Attribute to indicate that a property can be nullable.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class MappingNullable : Attribute, IValidator
{
    /// <summary>
    ///     Gets or sets the type of error that occurred.
    /// </summary>
    public ErrorType ErrorType { get; set; }

    /// <summary>
    ///     Validates whether the source object is not null.
    /// </summary>
    /// <param name="source">The source object to validate.</param>
    /// <returns>True if the source object is not null; otherwise, false.</returns>
    public bool IsValid(object? source)
    {
        return source != null;
    }
}

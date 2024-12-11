using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper.Attributes;

/// <summary>
///     Attribute to mark a property as required for mapping validation.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class MapperRequieredProperty : Attribute, IValidator
{
    /// <summary>
    ///     Gets or sets the type of error that occurs when validation fails.
    /// </summary>
    public ErrorType ErrorType { get; set; }

    /// <summary>
    ///     Validates whether the specified source object is not null.
    /// </summary>
    /// <param name="source">The source object to validate.</param>
    /// <returns><c>true</c> if the source object is not null; otherwise, <c>false</c>.</returns>
    public bool IsValid(object? source)
    {
        return source != null;
    }
}

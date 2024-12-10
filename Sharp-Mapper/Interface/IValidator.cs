using Sharp_Mapper.Result;

namespace Sharp_Mapper.Interface;

/// <summary>
///     Interface for validation logic.
/// </summary>
public interface IValidator
{
    /// <summary>
    ///     Gets or sets the type of error encountered during validation.
    /// </summary>
    public ErrorType ErrorType { get; set; }

    /// <summary>
    ///     Validates the specified source object.
    /// </summary>
    /// <param name="source">The source object to validate.</param>
    /// <returns><c>true</c> if the source object is valid; otherwise, <c>false</c>.</returns>
    bool IsValid(object? source);
}
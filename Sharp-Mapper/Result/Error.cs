using System.ComponentModel;

namespace Sharp_Mapper.Result;

/// <summary>
///     Enumeration of possible error types.
/// </summary>
public enum ErrorType
{
    /// <summary>
    ///     Indicates a successful operation.
    /// </summary>
    Success,

    /// <summary>
    ///     Indicates an unknown error.
    /// </summary>
    [Description("Unknown error")] Unknown,

    /// <summary>
    ///     Indicates that source properties do not match.
    /// </summary>
    [Description("Source propertys doesnt match")]
    MatchingProperty,

    /// <summary>
    ///     Indicates that a required source property was empty.
    /// </summary>
    [Description("Source property was empty")]
    RequieredProperty,

    /// <summary>
    ///     Indicates that a property is not mappable.
    /// </summary>
    [Description("Property is not mappable")]
    NotMappableProperty,

    /// <summary>
    ///     Indicates that if a property is null.
    /// </summary>
    [Description("Property was null")] NullProperty
}

/// <summary>
///     Represents an error with a description and type.
/// </summary>
public class Error
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Error" /> class.
    /// </summary>
    /// <param name="description">The description of the error.</param>
    /// <param name="errorType">The type of the error.</param>
    private Error(
        string description,
        ErrorType errorType
    )
    {
        Type = ErrorExtension.GetHeader(errorType);
        Description = description;
        ErrorType = errorType;
    }

    /// <summary>
    ///     Gets the type of the error.
    /// </summary>
    public string Type { get; }

    /// <summary>
    ///     Gets the description of the error.
    /// </summary>
    public string Description { get; }

    /// <summary>
    ///     Gets the error type.
    /// </summary>
    public ErrorType ErrorType { get; }

    /// <summary>
    ///     Creates a new <see cref="Error" /> instance.
    /// </summary>
    /// <param name="description">The description of the error.</param>
    /// <param name="errorType">The type of the error.</param>
    /// <returns>A new <see cref="Error" /> instance.</returns>
    public static Error Create(string description, ErrorType errorType)
    {
        return new Error(description, errorType);
    }
}
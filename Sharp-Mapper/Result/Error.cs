using Sharp_Mapper.Helper;
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
    ///     Indicates that a destination property was set.
    /// </summary>
    [Description("Destination property was set")]
    PropertySet,

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
    ///     Indicates that a property is null.
    /// </summary>
    [Description("Property was null")]
    NullProperty,

    /// <summary>
    ///     Indicates that a property for combining was empty.
    /// </summary>
    [Description("Property for combining was empty")]
    CombinePropEmpty,

    /// <summary>
    ///     Indicates that properties couldn't be combined.
    /// </summary>
    [Description("Couldn't combine properties")]
    CombineError,

    /// <summary>
    ///     Indicates a type mismatch error.
    /// </summary>
    [Description("Type mismatch error")]
    TypeMismatch,

    /// <summary>
    ///     Indicates an invalid assignment error.
    /// </summary>
    [Description("Invalid assignment error")]
    InvalidAssignment,
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
    /// <param name="exception">The exception associated with the error, if any.</param>
    private Error(
        string description,
        ErrorType errorType,
        Exception? exception = null
    )
    {
        Type = ErrorHelper.GetHeader(errorType);
        Description = description;
        ErrorType = errorType;
        Exception = exception;
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
    ///     Gets the exception associated with the error, if any.
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    ///     Creates a new <see cref="Error" /> instance.
    /// </summary>
    /// <param name="description">The description of the error.</param>
    /// <param name="errorType">The type of the error.</param>
    /// <param name="exception">The exception associated with the error, if any.</param>
    /// <returns>A new <see cref="Error" /> instance.</returns>
    public static Error Create(string description, ErrorType errorType, Exception? exception = null)
    {
        return new Error(description, errorType, exception);
    }
}

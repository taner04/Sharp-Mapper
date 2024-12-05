using System.ComponentModel;

namespace Sharp_Mapper.Result;

public enum ErrorType
{
    Success,
    [Description("Unknown error")]
    Unknown,
    [Description("Source property was empty")]
    RequieredProperty,
    [Description("Property is not mappable")]
    NotMappableProperty,
    [Description("Source Class is not mappable")]
    NotMappableClass,
}

public class Error
{
    private Error(
        string description,
        ErrorType errorType
    )
    {
        Header = ErrorExtension.GetHeader(errorType);
        Description = description;
        ErrorType = errorType;
    }

    public string Header { get; }

    public string Description { get; }

    public ErrorType ErrorType { get; }

    public static Error Create(string description, ErrorType errorType) => new(description, errorType);   
}
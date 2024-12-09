namespace Sharp_Mapper.Result;

/// <summary>
///     Represents the result of an operation, indicating success or failure.
/// </summary>
public class Result
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="Result" /> class indicating success.
    /// </summary>
    protected Result()
    {
        IsSuccess = true;
        Error = default;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Result" /> class indicating failure.
    /// </summary>
    /// <param name="error">The error associated with the failure.</param>
    protected Result(Error error)
    {
        IsSuccess = false;
        Error = error;
    }

    /// <summary>
    ///     Gets a value indicating whether the result is successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    ///     Gets the error associated with the result, if any.
    /// </summary>
    public Error? Error { get; }

    /// <summary>
    ///     Implicitly converts an <see cref="Error" /> to a <see cref="Result" /> indicating failure.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    public static implicit operator Result(Error error)
    {
        return new Result(error);
    }

    /// <summary>
    ///     Creates a new <see cref="Result" /> indicating success.
    /// </summary>
    /// <returns>A <see cref="Result" /> indicating success.</returns>
    public static Result Success()
    {
        return new Result();
    }

    /// <summary>
    ///     Creates a new <see cref="Result" /> indicating failure.
    /// </summary>
    /// <param name="error">The error associated with the failure.</param>
    /// <returns>A <see cref="Result" /> indicating failure.</returns>
    public static Result Failure(Error error)
    {
        return new Result(error);
    }
}
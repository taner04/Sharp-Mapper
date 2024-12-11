namespace Sharp_Mapper.Result;

/// <summary>
///     Represents a result that can either be a success or a failure, with an associated value of type
///     <typeparamref name="TValue" />.
/// </summary>
/// <typeparam name="TValue">The type of the value associated with a successful result.</typeparam>
public sealed class ResultT<TValue> : Result
{
    private readonly TValue? _value;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ResultT{TValue}" /> class with a successful result.
    /// </summary>
    /// <param name="value">The value associated with the successful result.</param>
    private ResultT(
        TValue value
    )
    {
        _value = value;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ResultT{TValue}" /> class with a failure result.
    /// </summary>
    /// <param name="error">The error associated with the failure result.</param>
    private ResultT(
        Error error
    ) : base(error)
    {
        _value = default;
    }

    /// <summary>
    ///     Gets the value associated with the successful result.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when the result is not successful.</exception>
    public TValue Value =>
        IsSuccess ? _value! : throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");

    /// <summary>
    ///     Implicitly converts an <see cref="Error" /> to a <see cref="ResultT{TValue}" /> representing a failure result.
    /// </summary>
    /// <param name="error">The error to convert.</param>
    public static implicit operator ResultT<TValue>(Error error)
    {
        return new ResultT<TValue>(error);
    }

    /// <summary>
    ///     Implicitly converts a value of type <typeparamref name="TValue" /> to a <see cref="ResultT{TValue}" /> representing
    ///     a successful result.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator ResultT<TValue>(TValue value)
    {
        return new ResultT<TValue>(value);
    }

    /// <summary>
    ///     Creates a new <see cref="ResultT{TValue}" /> representing a successful result.
    /// </summary>
    /// <param name="value">The value associated with the successful result.</param>
    /// <returns>A new <see cref="ResultT{TValue}" /> representing a successful result.</returns>
    public static ResultT<TValue> Success(TValue value)
    {
        return new ResultT<TValue>(value);
    }

    /// <summary>
    ///     Creates a new <see cref="ResultT{TValue}" /> representing a failure result.
    /// </summary>
    /// <param name="error">The error associated with the failure result.</param>
    /// <returns>A new <see cref="ResultT{TValue}" /> representing a failure result.</returns>
    public new static ResultT<TValue> Failure(Error error)
    {
        return new ResultT<TValue>(error);
    }
}

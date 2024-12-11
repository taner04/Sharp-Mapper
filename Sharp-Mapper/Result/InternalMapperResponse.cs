namespace Sharp_Mapper.Result
{
    /// <summary>
    /// Represents the response from an internal mapping operation.
    /// </summary>
    public record InternalMapperResponse
    {
        /// <summary>
        /// Gets or sets the type of error that occurred during the mapping operation.
        /// </summary>
        public ErrorType ErrorType { get; set; }

        /// <summary>
        /// Gets or sets the exception that was thrown during the mapping operation, if any.
        /// </summary>
        public Exception? Exception { get; set; }
    }
}

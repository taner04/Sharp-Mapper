using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper.Validation_Attributes
{
    /// <summary>
    /// Attribute to indicate that a property should be ignored by the mapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class MapperIgnoreProperty : Attribute, IValidation
    {
        /// <summary>
        /// Gets or sets the type of error that occurred during validation.
        /// </summary>
        public ErrorType ErrorType { get; set; }

        /// <summary>
        /// Determines whether the specified source object is valid.
        /// </summary>
        /// <param name="source">The source object to validate.</param>
        /// <returns>True if the source object is valid; otherwise, false.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public bool IsValid(object? source) => true;
    }
}

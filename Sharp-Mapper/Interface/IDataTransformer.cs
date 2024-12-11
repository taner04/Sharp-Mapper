using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Interface;

/// <summary>
///     Defines a method to combine an object with a source object.
/// </summary>
public interface IDataTransformer
{
    /// <summary>
    ///     Gets the name of the first property.
    /// </summary>
    string PropertyName1 { get; }

    /// <summary>
    ///     Gets the name of the second property.
    /// </summary>
    string PropertyName2 { get; }

    /// <summary>
    ///     Combines the current object with the specified source object.
    /// </summary>
    /// <typeparam name="TDestination">The type of the destination object.</typeparam>
    /// <param name="source">The source object to combine with.</param>
    /// <param name="mappableObject">The object to map the source properties to.</param>
    /// <param name="value">The resulting combined value.</param>
    /// <returns>An <see cref="ErrorType"/> indicating the result of the combination.</returns>
    ErrorType Combine<TDestination>(PropertyInfo[] source, TDestination mappableObject, out object? value);
}

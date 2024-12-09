namespace Sharp_Mapper.Interface;

/// <summary>
///     Defines a method to combine an object with a source object.
/// </summary>
public interface IDataTransformer
{
    string PropertyName1 { get; set; }
    string PropertyName2 { get; set; }

    /// <summary>
    ///     Combines the current object with the specified source object.
    /// </summary>
    /// <param name="source">The source object to combine with.</param>
    /// <returns>A new object that is the result of the combination.</returns>
    object Combine(object[]? source);
}
namespace Sharp_Mapper.Interface;

public interface ISubtract
{
    object PropertyName1 { get; set; }
    object PropertyName2 { get; set; }

    /// <summary>
    ///     Combines the current object with the specified source object.
    /// </summary>
    /// <param name="source">The source object to combine with.</param>
    /// <returns>A new object that is the result of the combination.</returns>
    object Combine(object[]? source);
}
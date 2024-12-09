using Sharp_Mapper.Interface;

namespace Sharp_Mapper.Mapper.Costum_Attributes
{
    /// <summary>
    /// Attribute to combine two string properties of a source object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class MapperCombineString(string value1, string value2) : Attribute, ICombiner
    {
        public object Value1 { get; set; } = value1;
        public object Value2 { get; set; } = value2;

        /// <summary>
        /// Combines the values of the specified properties from the source object.
        /// </summary>
        /// <param name="source">The source object containing the properties to combine.</param>
        /// <returns>A string that is the combination of the two property values, separated by a space.</returns>
        public object Combine(object[]? source)
        {
            if (source != null && (source[0].Equals(null) || source[1].Equals(null)))
            {
                return default!;
            }
            return string.Join(" ", source);
        }
    }
}
using Sharp_Mapper.Interface;

namespace Sharp_Mapper.Mapper.Costum_Attributes
{
    /// <summary>
    /// Attribute to combine two string properties of a source object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class MapperCombineString(string value1, string value2) : Attribute, ICombiner
    {
        /// <summary>
        /// Combines the values of the specified properties from the source object.
        /// </summary>
        /// <param name="source">The source object containing the properties to combine.</param>
        /// <returns>A string that is the combination of the two property values, separated by a space.</returns>
        public object Combine(object? source)
        {
            var type = source?.GetType();
            var prop1 = type?.GetProperty(value1);
            var prop2 = type?.GetProperty(value2);

            if (prop1 != null && prop2 != null)
                return string.Join(" ", prop1.GetValue(source), prop2.GetValue(source));
            return default!;
        }
    }
}

using Sharp_Mapper.Interface;

namespace Sharp_Mapper.Mapper.Costum_Attributes
{
    /// <summary>
    /// Attribute to combine two numeric properties of a source object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class MapperCombineNumbers(object value1, object value2) : Attribute, ICombiner
    {
        public object Value1 { get; set; } = value1;
        public object Value2 { get; set; } = value1;

        /// <summary>
        /// Combines the values of the specified properties from the source object.
        /// </summary>
        /// <param name="source">The source object containing the properties to combine.</param>
        /// <returns>The combined value of the specified properties, or the default value if the properties are not found or null.</returns>
        public object Combine(object[]? source)
        {
            var type = source.GetType();
            var prop1 = type.GetProperty(_value1?.ToString() ?? string.Empty);
            var prop2 = type.GetProperty(_value2?.ToString() ?? string.Empty);

            if (prop1 == null || prop2 == null)
                return default!;
            }
            return (dynamic)source[0] + (dynamic)source[1];
        }
    }
}

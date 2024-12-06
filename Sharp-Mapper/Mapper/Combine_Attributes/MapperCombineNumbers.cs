using Sharp_Mapper.Interface;

namespace Sharp_Mapper.Mapper.Costum_Attributes
{
    /// <summary>
    /// Attribute to combine two numeric properties of a source object.
    /// </summary>
    /// <typeparam name="TType">The type of the properties to combine.</typeparam>
    [AttributeUsage(AttributeTargets.Property)]
    internal class MapperCombineNumbers<TType> : Attribute, ICombiner
    {
        private readonly TType _value1;
        private readonly TType _value2;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapperCombineNumbers{TType}"/> class.
        /// </summary>
        /// <param name="value1">The name of the first property to combine.</param>
        /// <param name="value2">The name of the second property to combine.</param>
        public MapperCombineNumbers(TType value1, TType value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        /// <summary>
        /// Combines the values of the specified properties from the source object.
        /// </summary>
        /// <param name="source">The source object containing the properties to combine.</param>
        /// <returns>The combined value of the specified properties, or the default value if the properties are not found or null.</returns>
        public object Combine(object? source)
        {
            var type = source?.GetType();
            var prop1 = type?.GetProperty(_value1?.ToString() ?? string.Empty);
            var prop2 = type?.GetProperty(_value2?.ToString() ?? string.Empty);

            if (prop1 == null || prop2 == null)
                return default!;

            var value3 = prop1.GetValue(source);
            var value4 = prop2.GetValue(source);
            if (value3 != null && value4 != null)
            {
                return (TType)(object)((dynamic)value3 + (dynamic)value4);
            }
            return default!;
        }
    }
}

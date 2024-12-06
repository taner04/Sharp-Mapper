using Sharp_Mapper.Interface;

namespace Sharp_Mapper.Mapper.Costum_Attributes
{
    //TODO: Implement the MapperCombineNumbers attribute
    [AttributeUsage(AttributeTargets.Property)]
    internal class MapperCombineNumbers<TType> : Attribute, ICombiner
    {
        private readonly TType _value1;
        private readonly TType _value2;

        public MapperCombineNumbers() { }

        public MapperCombineNumbers(TType value1, TType value2)
        {
            _value1 = value1;
            _value2 = value2;
        }

        public object Combine(object? source)
        {
            var type = source.GetType();
            var prop1 = type.GetProperty(_value1?.ToString() ?? string.Empty);
            var prop2 = type.GetProperty(_value2?.ToString() ?? string.Empty);

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

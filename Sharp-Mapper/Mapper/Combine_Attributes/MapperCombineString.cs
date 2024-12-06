namespace Sharp_Mapper.Mapper.Costum_Attributes
{
    //TODO: Implement the MapperCombineString attribute
    [AttributeUsage(AttributeTargets.Property)]
    internal class MapperCombineString(string value1, string value2) : Attribute
    {
        public string? Combine(object? source)
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

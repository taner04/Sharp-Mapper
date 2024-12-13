using Sharp_Mapper.Interface;
using System.Reflection;

namespace Sharp_Mapper.Helper
{
    internal static class DataTransformerHelper
    {
        public static object[] GetValues<TDestination>(PropertyInfo[] sourceProperty, TDestination destinationObject, IDataTransformer dataTransformer)
        {
            var values = new object[2];

            foreach(var property in sourceProperty)
            {
                if(property.Name == dataTransformer.PropertyName1)
                {
                    values[0] = property.GetValue(destinationObject)!;
                }
                if(property.Name == dataTransformer.PropertyName2)
                {
                    values[1] = property.GetValue(destinationObject)!;
                }
            }

            return values;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper
{
    public class MapperExtension<TSource>
    {
        private static Dictionary<Attribute, ErrorType> Attributes => new()
        {
            { new RequieredProperty(), ErrorType.RequieredProperty },
            { new NotMappableProperty(), ErrorType.NotMappableProperty }
        };
        
        public static ErrorType CheckAttributes(PropertyInfo sourceProperty, PropertyInfo destinationProperty, TSource source)
        {
            var atr = destinationProperty.GetCustomAttributes(typeof(Attribute), true);
            if (destinationProperty != null)
            {
                foreach (var item in Attributes)
                {
                    var atrTypes = destinationProperty.GetCustomAttributes(typeof(Attribute), true);
                    foreach (var t in atrTypes)
                    {
                        if (atrTypes[0].GetType() != item.Key.GetType()) continue;
                        
                        if(item.Key.GetType() == typeof(RequieredProperty) && sourceProperty.GetValue(source) == null)
                        {
                            return ErrorType.RequieredProperty;
                        }
                        return item.Value;
                    }
                }
                return ErrorType.Success;
            }
            return ErrorType.Unknown;
        }

        public static object? SetProperty(object? value) => value ?? null;
    }
}

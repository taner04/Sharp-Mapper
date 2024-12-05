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
            { new NotMappableProperty(), ErrorType.NotMappableProperty },
            { new IgnoreProperty(), ErrorType.IgnoreProperty}
        };
        
        public static ErrorType CheckAttributes(PropertyInfo sourceProperty, PropertyInfo destinationProperty, TSource source)
        {
            // Get all attributes applied to the destination property
            var attributes = sourceProperty.GetCustomAttributes(true).OfType<Attribute>().ToList();

            foreach (var attribute in attributes)
            {
                // Check for NotMappableProperty
                if (attribute is NotMappableProperty)
                {
                    return ErrorType.NotMappableProperty;
                }

                // Check for IgnoreProperty
                if (attribute is IgnoreProperty)
                {
                    return ErrorType.IgnoreProperty;
                }

                // Check for RequieredProperty and validate value
                if (attribute is RequieredProperty && sourceProperty.GetValue(source) == null)
                {
                    return ErrorType.RequieredProperty;
                }
            }

            return ErrorType.Success;
        }


        public static object? SetProperty(object? value) => value ?? null;

        public static object? GetAttribute(object? value)
        {
            var atr = value?.GetType().GetCustomAttributes(typeof(Attribute), true);
            return atr?.Length > 0 ? atr[0] : null;
        }
    }
}

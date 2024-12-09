using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper.Costum_Attributes;
using Sharp_Mapper.Mapper.Validation_Attributes;
using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Mapper;

/// <summary>
/// Provides extension methods for mapping properties between source and destination objects.
/// </summary>
/// <typeparam name="TDestination">The type of the destination object.</typeparam>
/// <typeparam name="TSource">The type of the source object.</typeparam>
public class MapperExtension<TDestination, TSource>
{
    /// <summary>
    /// Gets a dictionary of attributes and their corresponding error types.
    /// </summary>

    public bool ContainsCombineAttribute(List<Attribute>? attributes, out ICombiner combiner)
    {
        if (attributes != null)
        {
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(MapperCombineString))
                {
                    combiner = (ICombiner)attribute;
                    return true;
                }
                if (attribute.GetType() == typeof(MapperCombineNumbers))
                {
                    combiner = (ICombiner)attribute;
                    return true;
                }
            }
        }

        combiner = null!;
        return false;
    }

    public bool ContainsValidationAttribute(List<Attribute>? attributes, out IValidation validator)
    {
        if (attributes != null)
        {
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(MapperRequieredProperty))
                {
                    validator = (IValidation)attribute;
                    validator.ErrorType = ErrorType.RequieredProperty;
                    return true;
                }
            }
        }

        validator = null!;
        return false;
    }

    public object[] GetCombinerValues(PropertyInfo[] propertys, ICombiner combiner, TSource mappableObject)
    {
        var combinerValues = new object[2];
        foreach (var sourceProperty in propertys)
        {
            if (sourceProperty.Name == (string)combiner.Value1)
            {
                combinerValues[0] = sourceProperty.GetValue(mappableObject)!;
            }
            if (sourceProperty.Name == (string)combiner.Value2)
            {
                combinerValues[1] = sourceProperty.GetValue(mappableObject)!;
            }
        }
        return combinerValues;
    }
}

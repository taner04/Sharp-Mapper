using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper.Data_Transformer;
using Sharp_Mapper.Mapper.Validation_Attributes;
using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Mapper;

/// <summary>
///     Provides extension methods for mapping properties between source and destination objects.
/// </summary>
/// <typeparam name="TDestination">The type of the destination object.</typeparam>
/// <typeparam name="TSource">The type of the source object.</typeparam>
public class MapperHelper<TDestination, TSource>
{
    /// <summary>
    ///     Gets a dictionary of attributes and their corresponding error types.
    /// </summary>
    public bool ContainsCombineAttribute(List<Attribute>? attributes, out IDataTransformer dataTransformer)
    {
        if (attributes != null)
        {
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(MapStrings))
                {
                    dataTransformer = (IDataTransformer)attribute;
                    return true;
                }

                if (attribute.GetType() == typeof(MapNumerics))
                {
                    dataTransformer = (IDataTransformer)attribute;
                    return true;
                }
            }
        }

        dataTransformer = null!;
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

    public object[] GetValuesForCombinerAtr(PropertyInfo[] propertys, IDataTransformer dataTransformer, TSource mappableObject)
    {
        var combinerValues = new object[2];
        foreach (var sourceProperty in propertys)
        {
            if (sourceProperty.Name == (string)dataTransformer.PropertyName1)
                combinerValues[0] = sourceProperty.GetValue(mappableObject)!;
            if (sourceProperty.Name == (string)dataTransformer.PropertyName2)
                combinerValues[1] = sourceProperty.GetValue(mappableObject)!;
        }

        return combinerValues;
    }
}
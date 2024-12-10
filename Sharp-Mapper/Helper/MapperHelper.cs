using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper.Attributes;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Helper;

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
                var atrType = attribute.GetType();
                if (atrType != typeof(MapNumerics) && atrType != typeof(MapStrings)) continue;

                dataTransformer = (IDataTransformer)attribute;
                return true;
            }
        }

        dataTransformer = null!;
        return false;
    }

    public bool ContainsValidationAttribute(List<Attribute>? attributes, out IValidator validator)
    {
        if (attributes != null)
        {
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() != typeof(MapperRequieredProperty)) continue;

                validator = (IValidator)attribute;
                validator.ErrorType = ErrorType.RequieredProperty;
                return true;
            }
        }

        validator = null!;
        return false;
    }
}
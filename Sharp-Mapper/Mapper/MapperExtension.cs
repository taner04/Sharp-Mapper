using Sharp_Mapper.Interface;
using Sharp_Mapper.Mapper.Costum_Attributes;
using Sharp_Mapper.Mapper.Validation_Attributes;
using Sharp_Mapper.Result;

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
                if (attribute.GetType() == typeof(MapperCombineNumbers<object>))
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

    /// <summary>
    /// Sets the property value.
    /// </summary>
    /// <param name="value">The value to set.</param>
    /// <returns>The set value or null.</returns>
    public object? SetProperty(object? value)
    {
        return value ?? null;
    }

    /// <summary>
    /// Gets the first attribute of the specified value.
    /// </summary>
    /// <param name="value">The value to get the attribute from.</param>
    /// <returns>The first attribute or null if no attributes are found.</returns>
    public object? GetAttribute(object? value)
    {
        var atr = value?.GetType().GetCustomAttributes(typeof(Attribute), true);
        return atr?.Length > 0 ? atr[0] : null;
    }
}

using Sharp_Mapper.Result;
using System.Reflection;

namespace Sharp_Mapper.Mapper;

public sealed partial class Mapper<TDestination, TSource>
{
    public void Update<TType>(object source, ref TType destination)
    {
        switch (destination)
        {
            case TDestination:
            {
                UpdateProperties(source, ref destination, SourceProperties, DestinationPropertyInfos);
                break;
            }
            case TSource:
            {
                UpdateProperties(source, ref destination, DestinationProperties, SourcePropertiesInfo);
                break;
            }
        }
    }

    private void UpdateProperties<T>(object source, ref T destinationObject, Dictionary<string, PropertyInfo> sourceProperties, PropertyInfo[] destinationProperties)
    {
        foreach (var destinationProperty in destinationProperties)
        {
            if (!sourceProperties.TryGetValue(destinationProperty.Name, out var sourceProp)) continue;
            
            var sourceValue = source?.GetType().GetProperty(sourceProp.Name)?.GetValue(source);
            if (sourceValue == null) continue;

            var error = MapperHelper.SetPropertyValue(destinationProperty, sourceValue, destinationObject, IgnoreNullValues);
            if (error != ErrorType.Success)
            {
                throw new Exception(ErrorExtension.GetDescription(sourceProp, destinationProperty, error));
            }
        }
    }
}
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper
{
    public sealed partial class Mapper<TDestination, TSource>
    {
        public void Update<TType>(object source, ref TType destination)
        {
            switch (destination)
            {
                case TDestination:
                    {
                        UpdateDestination(source, ref destination);
                        break;
                    }
                case TSource:
                    {
                        UpdateSource(source, ref destination);
                        break;
                    }
            }
        }

        private void UpdateSource<T>(object source, ref T destination)
        {
            foreach (var sourceProp in SourcePropertiesInfo)
            {
                if (DestinationProperties.TryGetValue(sourceProp.Name, out var destProp))
                {
                    var type = source?.GetType().GetProperty(destProp.Name);
                    var value = type?.GetValue(source);

                    if (value == null)
                        continue;

                    var error = SetPropertyValue(sourceProp, value, destination);
                    if (error != ErrorType.Success)
                    {
                        throw new Exception(ErrorExtension.GetDescription(sourceProp, destProp, error));
                    }
                }
            }
        }

        private void UpdateDestination<T>(object source, ref T destination)
        {
            foreach (var destinProp in DestinationPropertyInfos)
            {
                if (SourceProperties.TryGetValue(destinProp.Name, out var soureProp))
                {
                    var type = source?.GetType().GetProperty(soureProp.Name);
                    var value = type?.GetValue(source);

                    if (value == null)
                        continue;

                    var error = SetPropertyValue(destinProp, value, destination);
                    if (error != ErrorType.Success)
                    {
                        throw new Exception(ErrorExtension.GetDescription(destinProp, soureProp, error));
                    }
                }
            }
        }
    }
}

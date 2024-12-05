using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Sharp_Mapper.Interface;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Mapper
{
    public class MapperT<TDestination, TSource>(bool ignoreAttributes = true) : IMapper<TDestination, TSource>
    {
        private bool IgnoreAttributes { get; set; } = ignoreAttributes;
        
        private static readonly PropertyInfo[] _destinationProperties =
            typeof(TDestination).GetProperties();
        private static readonly PropertyInfo[] _sourceProperties = typeof(TSource).GetProperties();
        
        public void EnableIgnoreAttributes() => IgnoreAttributes = true;
        public void DisableIgnoreAttributes() => IgnoreAttributes = false;
        
        public ResultT<TDestination> Map(TSource source)
        {
            var obj = Activator.CreateInstance<TDestination>();
            foreach (var destinProp in _destinationProperties)
            {
                foreach (var sourceProp in _sourceProperties)
                {
                    if (IgnoreAttributes)
                    {
                        if (destinProp.Name != sourceProp.Name) continue;
                        
                        var value = MapperExtension<TSource>.SetProperty(sourceProp.GetValue(source));
                        destinProp.SetValue(obj, value);
                    }
                    else
                    {
                        var error = MapperExtension<TSource>.CheckAttributes(sourceProp, destinProp, source);
                        if (error == ErrorType.Success)
                        {
                            var value = MapperExtension<TSource>.SetProperty(sourceProp.GetValue(source));
                            destinProp.SetValue(obj, sourceProp.GetValue(value));
                        }
                        else
                        {
                            return ResultT<TDestination>.Failure(Error.Create("TEst", error));
                        }
                    }
                }
            }
            return ResultT<TDestination>.Success(obj);
        }
    }
}

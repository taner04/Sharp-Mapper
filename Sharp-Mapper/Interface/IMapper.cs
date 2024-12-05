using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sharp_Mapper.Result;

namespace Sharp_Mapper.Interface
{
    public interface IMapper<TDestination, in TSource>
    {
        ResultT<TDestination> Map(TSource source);
    }
}

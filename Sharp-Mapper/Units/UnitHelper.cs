using Sharp_Mapper.Result;

namespace Sharp_Mapper.Units;

internal static class UnitHelper
{
    public static void PrintSuccess(string testType)
    {
        Console.WriteLine($"Test '{testType}' passed!");
    }

    public static void PrintFail(string testType)
    {
        Console.WriteLine($"Test '{testType}' failed!");
    }

    public static void PrintError<T>(ResultT<T> mapperResponse)
    {
        Console.WriteLine("Error: Mapping error");
        Console.WriteLine($"Header {mapperResponse.Error?.Type}");
        Console.WriteLine($"Header {mapperResponse.Error?.Description}");
    }
}
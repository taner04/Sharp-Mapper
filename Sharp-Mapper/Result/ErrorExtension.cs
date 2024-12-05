using System.ComponentModel;

namespace Sharp_Mapper.Result;

public static class ErrorExtension
{
    public static string GetHeader(ErrorType errorType)
    {
        var fi = errorType.GetType().GetField(errorType.ToString());
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : errorType.ToString();
    }
}
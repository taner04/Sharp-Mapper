namespace Sharp_Mapper.Units.Test_Objects.String;

internal class StringModel
{
    public string Value1 { get; set; }
    public string Value2 { get; set; }

    public static StringModel GetTestObject(string value1, string value2)
    {
        return new StringModel
        {
            Value1 = value1,
            Value2 = value2
        };
    }
}
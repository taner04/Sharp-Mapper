using Sharp_Mapper.Mapper.Attributes;

namespace Mapper.Units.Test.Objects.String
{
    internal class StringModelDto
    {
        [MapStrings("Value1", "Value2")]
        public string Result { get; set; }
    }
}

using Sharp_Mapper.Mapper.Data_Transformer;

namespace Mapper_Units.Test_Objects.String
{
    internal class StringModelDto
    {
        [MapStrings("Value1", "Value2")]
        public string Result { get; set; }
    }
}

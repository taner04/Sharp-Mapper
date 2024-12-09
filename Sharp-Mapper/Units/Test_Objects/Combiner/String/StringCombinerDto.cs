using Sharp_Mapper.Mapper.Costum_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Combiner.String
{
    internal class StringCombinerDto
    {
        [MapperCombineString("Firstname", "Lastname")]
        public string Fullname { get; set; }
    }
}

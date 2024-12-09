using Sharp_Mapper.Mapper.Costum_Attributes;

namespace Sharp_Mapper.Units.Test_Objects.Combiner_Objects
{
    internal class CombinerDto
    {
        [MapperCombineString("Firstname", "Lastname")]
        public string Fullname { get; set; }
    }
}

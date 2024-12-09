namespace Sharp_Mapper.Units.Test_Objects.Combiner.String_Combiner
{
    internal class StringCombiner
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public static StringCombiner GetTestObject()
        {
            return new StringCombiner
            {
                Firstname = "John",
                Lastname = "Doe"
            };
        }
    }
}

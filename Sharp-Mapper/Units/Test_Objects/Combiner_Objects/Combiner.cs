namespace Sharp_Mapper.Units.Test_Objects.Combiner_Objects
{
    internal class Combiner
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public static Combiner GetTestObject()
        {
            return new Combiner
            {
                Firstname = "John",
                Lastname = "Doe"
            };
        }
    }
}

namespace Mapper_Units.Test_Objects
{
    internal class EmployeeDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public static EmployeeDto GetTestObject()
        {
            return new EmployeeDto
            {
                Id = 1,
                Firstname = "Thomas",
                Lastname = "Müller"
            };
        }
    }
}

namespace Mapper_Units.Test_Objects
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public static Employee GetTestObject()
        {
            return new Employee
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Doe",
                Email = "johndoe@mail.de",
                Phone = "123456789"
            };
        }
    }
}

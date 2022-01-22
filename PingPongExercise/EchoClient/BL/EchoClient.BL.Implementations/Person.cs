
namespace EchoClient.BL.Implementations
{
    public class Person
    {
        public string _name { get; set; }
        public int _age { get; set; }

        public Person(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"{_name} is {_age} years old.";
        }
    }
}

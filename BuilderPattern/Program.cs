using System;

namespace BuilderPattern
{
    public class Person
    {
        public string Name;
        public string Position;
    }

    public class PersonInfoBuilder
    {
        protected Person person = new Person(); 

        public PersonInfoBuilder Called(string name)
        {
            person.Name = name;
            return this; 
        }

        public PersonInfoBuilder WorkAs(string position)
        {
            person.Position = position;
            return this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new PersonInfoBuilder();
            builder.Called("Antonio").WorkAs("Software Developer"); 
            
        }
    }
}

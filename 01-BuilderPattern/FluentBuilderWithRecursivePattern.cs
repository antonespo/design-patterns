using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class Person
    {
        public string Name;
        public string Position;
        public double Salary;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}, {nameof(Salary)}: {Salary}";
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder
        where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }

    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>>
        where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkAs(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }

    public class PersonSalaryBuilder<SELF> : PersonJobBuilder<PersonSalaryBuilder<SELF>>
        where SELF : PersonSalaryBuilder<SELF>
    {
        public SELF HasSalary(double salary)
        {
            person.Salary = salary;
            return (SELF)this;
        }
    }

    public class Builder : PersonSalaryBuilder<Builder>
    {
        public static Builder New => new Builder();
    }
}

namespace BuilderPattern
{
    public class Worker
    {
        public string Name, Address;

        public string Position, Salary;

        public override string ToString()
        {
            return $"{Name}, {Address}, {Position}, {Salary}";
        }
    }

    public class WorkerBuilder
    {
        protected Worker worker = new Worker();

        public IdentityBuilder Is => new IdentityBuilder(worker);
        public WorkBuilder Works => new WorkBuilder(worker);

        public Worker Build()
        {
            return worker;
        }
    }

    public class IdentityBuilder : WorkerBuilder
    {
        public IdentityBuilder(Worker worker)
        {
            this.worker = worker;
        }

        public IdentityBuilder Called(string name)
        {
            worker.Name = name;
            return this;
        }

        public IdentityBuilder LiveIn(string address)
        {
            worker.Address = address;
            return this;
        }
    }

    public class WorkBuilder : WorkerBuilder
    {
        public WorkBuilder(Worker worker)
        {
            this.worker = worker;
        }

        public WorkBuilder HasPosition(string position)
        {
            worker.Position = position;
            return this;
        }

        public WorkBuilder HasSalary(string salary)
        {
            worker.Salary = salary;
            return this;
        }
    }

}

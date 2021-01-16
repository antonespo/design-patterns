using System.Threading;

namespace SingletonPattern
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            // Static constructor
            var bus = new Bus(57);
            Thread.Sleep(500);
            var bus2 = new Bus(44);
            System.Console.WriteLine(bus.ToString());
            System.Console.WriteLine(bus2.ToString());


            // Singleton - property and monostate pattern
            //var ceo = new CEO();
            //CEO.Name = "Antonio";
            //ceo.Age = 30;
            //var ceo2 = new CEO();
            //Console.WriteLine($"Name - {CEO.Name}");
            //Console.WriteLine($"Age - {ceo2.Age}");


            // Singleton w/o DI - class
            //var db = SingletonDatabase.Instance;
            //var city = "Tokyo";
            //Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
            //db.Name = "Antonio";
            //var db1 = SingletonDatabase.Instance;
            //Console.WriteLine(db1.Name);

            //// Singleton w/ DI 2
            //var serviceProvider = ContainerConfig.Configure();
            //var recordFinder = serviceProvider.GetService<ConfigurableRecordFinder>();
            //var tot = recordFinder.GetTotalPopulation(new[] { "Tokyo", "New York" });
            //Console.WriteLine(tot);

            //// Singleton w/ DI - Suggested
            //var container = ContainerConfig.Configure();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    var recordFinder = scope.Resolve<ConfigurableRecordFinder>();
            //    var tot = recordFinder.GetTotalPopulation(new[] { "Tokyo", "New York" });
            //    Console.WriteLine(tot);
            //}
        }
    }
}

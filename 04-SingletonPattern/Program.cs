using Autofac;
using System;

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
            // Singleton with DI and Autofac - Suggested
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope())
            {
                var recordFinder = scope.Resolve<ConfigurableRecordFinder>();
                var tot = recordFinder.GetTotalPopulation(new[] { "Tokyo", "New York" });
                Console.WriteLine(tot);
            }

            // Singleton with DI and Autofac - Not Suggested
            //var serviceProvider = ContainerConfig.ConfigureServiceProvider();
            //var recordFinder = serviceProvider.GetService<ConfigurableRecordFinder>();
            //var tot = recordFinder.GetTotalPopulation(new[] { "Tokyo", "New York" });
            //Console.WriteLine(tot);



            // Singleton w/o DI - class
            //var db = SingletonDatabase.Instance;
            //db.Name = "City Database";
            //var city = "Tokyo";
            //Console.WriteLine($"{city} has population {db.GetPopulation(city)}");
            //var db2 = SingletonDatabase.Instance;
            //Console.WriteLine(db2.Name);

            // Static constructor
            //var bus = new Bus();
            //bus.BusNumber = 47;
            //Thread.Sleep(1500);
            //var bus2 = new Bus();
            //bus2.BusNumber = 47;
            //System.Console.WriteLine(bus.ToString());
            //System.Console.WriteLine(bus2.ToString());

            // Static property and monostate pattern
            //var ceo = new CEO();
            //CEO.Name = "Antonio";
            //ceo.Age = 30;
            //var ceo2 = new CEO();
            //Console.WriteLine($"Name - {CEO.Name}");
            //Console.WriteLine($"Age - {ceo2.Age}");
        }
    }
}

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
            // Singleton w/ DI
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();
            using (var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
                var tot = rf.GetTotalPopulation(new[] { "Tokyo", "New York" });
                Console.WriteLine(tot);
            }

            // Singleton w/o DI
            //var db = SingletonDatabase.Instance;
            //var city = "Tokyo";
            //Console.WriteLine($"{city} has popilation {db.GetPopulation(city)}");
        }
    }
}

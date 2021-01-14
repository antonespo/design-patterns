using Autofac;
using MoreLinq;
using SingletonPattern.WithoutDI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SingletonPattern
{
    public class ConfigurableRecordFinder
    {
        private IDatabase database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database;
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name);
            }
            return result;
        }
    }

    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        public OrdinaryDatabase()
        {
            Console.WriteLine("Initializing database");
            capitals = File.ReadAllLines("capitals.txt")
            .Batch(2)
            .ToDictionary(
            list => list.ElementAt(0).Trim(),
            list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
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

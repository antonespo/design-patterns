using System;
using System.Collections.Generic;

namespace SingletonPattern
{
    public interface IDatabase
    {
        int GetPopulation(string male);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        public SingletonDatabase()
        {
            Console.WriteLine("Initializing database");
            //capitals = File.ReadAllLines("capitals.txt")
            //    .Batch(2);
            //.ToDictionary(
            //list => list.ElementAt(0).Trim(),
            //list => int.Parse(list.ElementAt(1)));
        }

        public int GetPopulation(string male)
        {
            throw new NotImplementedException();
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
        }
    }
}

using PrototypePattern.Serialization;
using System;

namespace PrototypePattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Serialization Xml
            var user1 = new UserData(new[] { "Antonio", "Esposito" }, new Address("Via San Francesco", 15));
            var user2 = user1.DeepCopyXml();
            user2.Name[0] = "Maria";
            user2.address.HouseNumber = 35;
            Console.WriteLine(user1);
            Console.WriteLine(user2);

            // Serialization
            //var user1 = new UserData(new[] { "Antonio", "Esposito" }, new Address("Via San Francesco", 15));
            //var user2 = user1.DeepCopy();
            //user2.Name[0] = "Maria";
            //user2.address.HouseNumber = 35;
            //Console.WriteLine(user1);
            //Console.WriteLine(user2);

            //Explicit Deep Copy
            //var user1 = new UserData(new[] { "Antonio", "Esposito" }, new Address("Via San Francesco", 15));
            //var user2 = user1.DeepCopy();
            //user2.Name[0] = "Maria";
            //user2.address.HouseNumber = 35;
            //Console.WriteLine(user1);
            //Console.WriteLine(user2);

            // Copy Constructor
            //var user1 = new UserData(new[] { "Antonio", "Esposito" }, new Address("Via San Francesco", 15));
            //var user2 = new UserData(user1);
            //user2.Name[0] = "Maria";
            //user2.address.HouseNumber = 35;
            //Console.WriteLine(user1);
            //Console.WriteLine(user2);
        }
    }
}

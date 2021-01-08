using System;

namespace FactoryPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            // Simple Factory
            var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
            var origin = Point.Origin; // Property (new obj)
            Console.WriteLine(Point.Origin2); // Field (Singleton obj)

            Console.WriteLine(point);
        }
    }
}

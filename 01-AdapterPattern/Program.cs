using MoreLinq;
using System;
using System.Collections.Generic;

namespace _01_AdapterPattern
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            // Example 1: Peg & Hole 
            var roundPeg = new RoundPeg(5); 
            var roundHole = new RoundHole(7);

            Console.WriteLine($"The round peg fits the round hole: {roundHole.Fits(roundPeg)}");

            var squarePeg = new SquarePeg(10);
            // This returns an error because cannot convert
            // Console.WriteLine($"The square peg fits the round hole: {roundHole.Fits(squarePeg)}");

            var squarePegAdapter = new SquarePegAdapter(squarePeg);
            Console.WriteLine($"The square peg fits the round hole: {roundHole.Fits(squarePegAdapter)}");

            // Example 2
            Draw();
        }
    }

    public partial class Program
    {
        private static readonly List<VectorObject> vectorObjects =
            new List<VectorObject>
            {
              new VectorRectangle(1, 1, 10, 10),
              new VectorRectangle(3, 3, 6, 6)
            };

        public static void DrawPoint(Point p)
        {
            Console.Write(".");
        }
        private static void Draw()
        {
            foreach (var vo in vectorObjects)
            {
                foreach (var line in vo)
                {
                    var adapter = new LineToPointAdapter(line);
                    adapter.ForEach(DrawPoint);
                }
            }
        }
    }
}

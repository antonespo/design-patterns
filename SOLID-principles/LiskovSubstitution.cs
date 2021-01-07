using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID_principles
{
    public class Shape
    {
        public int W { get; }
        public int H { get; }

        public Shape(int w, int h)
        {
            W = w;
            H = h;
        }

        public virtual void PrintParameters()
        {
            Console.WriteLine($"{W}, {H}");
        }
    }

    public class Circle : Shape
    {
        public int Radius { get; }

        public Circle(int w, int h, int radius) : base(w, h)
        {
            Radius = radius;
        }

        public override void PrintParameters()
        {
            Console.WriteLine($"{W}, {H}, {Radius}");
        }
    }
}

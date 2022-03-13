using System;

namespace _01_AdapterPattern
{
    public class SquarePegAdapter : IRoundPeg
    {
        private readonly SquarePeg squarePeg;

        public SquarePegAdapter(SquarePeg squarePeg)
        {
            this.squarePeg = squarePeg;
        }

        public double Radius => squarePeg.Width * Math.Sqrt(2) / 2;
    }
}

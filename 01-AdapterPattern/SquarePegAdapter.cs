using System;

namespace _01_AdapterPattern
{
    public class SquarePegAdapter : RoundPeg
    {
        private readonly SquarePeg squarePeg;

        public SquarePegAdapter(SquarePeg squarePeg)
            : base(squarePeg.Width)
        {
            this.squarePeg = squarePeg;
        }

        public double Radius
        {
            get => squarePeg.Width * Math.Sqrt(2) / 2; 
        }
    }
}

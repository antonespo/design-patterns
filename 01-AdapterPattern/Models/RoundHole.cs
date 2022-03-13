namespace _01_AdapterPattern
{
    public class RoundHole
    {
        public double Radius { get; }

        public RoundHole(double radius)
        {
            Radius = radius;
        }

        public bool Fits(IRoundPeg roundPeg)
        {
            return roundPeg.Radius <= Radius;
        }
    }
}

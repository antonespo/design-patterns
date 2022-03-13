namespace _01_AdapterPattern
{
    public class RoundPeg : IRoundPeg
    {
        public double Radius { get; }

        public RoundPeg(double radius)
        {
            Radius = radius;
        }
    }
}

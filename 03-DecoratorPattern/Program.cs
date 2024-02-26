// Component interface
interface ICar
{
    void Assemble();
}

// Concrete component
class BasicCar : ICar
{
    public void Assemble()
    {
        Console.WriteLine("Basic Car Assembled");
    }
}

// Decorator base class
abstract class CarDecorator(ICar decoratedCar) : ICar
{
    protected ICar DecoratedCar { get; } = decoratedCar;

    public virtual void Assemble()
    {
        DecoratedCar.Assemble();
    }
}

// Concrete decorator 1
class LuxuryCarDecorator(ICar decoratedCar) : CarDecorator(decoratedCar)
{
    public override void Assemble()
    {
        base.Assemble();
        Console.WriteLine("Adding luxury features");
    }
}

// Concrete decorator 2
class SportsCarDecorator(ICar decoratedCar) : CarDecorator(decoratedCar)
{
    public override void Assemble()
    {
        base.Assemble();
        Console.WriteLine("Adding sports features");
    }
}

// Concrete decorator 3
class AdvancedTechCarDecorator(ICar decoratedCar) : CarDecorator(decoratedCar)
{
    public override void Assemble()
    {
        base.Assemble();
        Console.WriteLine("Adding advanced technology features");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a basic car
        ICar basicCar = new BasicCar();

        // Wrapping the basic car with multiple decorators
        LuxuryCarDecorator luxuryCar = new LuxuryCarDecorator(basicCar);
        SportsCarDecorator sportsLuxuryCar = new SportsCarDecorator(luxuryCar);
        AdvancedTechCarDecorator ultimateCar = new AdvancedTechCarDecorator(sportsLuxuryCar);

        // Assembling the ultimate car (basic car with additional features)
        ultimateCar.Assemble();
    }
}

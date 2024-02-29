// Subsystems
class Lights
{
    public void TurnOn() => Console.WriteLine("Lights: Turning on...");
    public void TurnOff() => Console.WriteLine("Lights: Turning off...");
}

class HVAC
{
    public void SetTemperature(int temperature) => Console.WriteLine($"HVAC: Setting temperature to {temperature}°C...");
    public void TurnOn() => Console.WriteLine("HVAC: Turning on...");
    public void TurnOff() => Console.WriteLine("HVAC: Turning off...");
}

class SecuritySystem
{
    public void Arm() => Console.WriteLine("Security System: Arming...");
    public void Disarm() => Console.WriteLine("Security System: Disarming...");
}

// Facade
class SmartHomeFacade
{
    private readonly Lights _lights;
    private readonly HVAC _hvac;
    private readonly SecuritySystem _securitySystem;

    public SmartHomeFacade()
    {
        _lights = new Lights();
        _hvac = new HVAC();
        _securitySystem = new SecuritySystem();
    }

    public void LeaveHome()
    {
        _lights.TurnOff();
        _hvac.TurnOff();
        _securitySystem.Arm();
        Console.WriteLine("Leaving home...");
    }

    public void ReturnHome()
    {
        _lights.TurnOn();
        _hvac.SetTemperature(22);
        _hvac.TurnOn();
        _securitySystem.Disarm();
        Console.WriteLine("Returning home...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var smartHomeFacade = new SmartHomeFacade();

        // Simulate leaving home
        smartHomeFacade.LeaveHome();

        // Simulate returning home
        smartHomeFacade.ReturnHome();
    }
}

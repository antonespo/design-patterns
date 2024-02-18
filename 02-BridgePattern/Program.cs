interface IDevice
{
    int Volume { get; set; }
    void PowerOn();
    void PowerOff();
    void SetChannel(double channel);
}

// Concrete Device Implementations
class TV : IDevice
{
    public int Volume { get; set; } = 10;
    public void PowerOn() => Console.WriteLine("TV is powered on");
    public void PowerOff() => Console.WriteLine("TV is powered off");
    public void SetChannel(double channel) => Console.WriteLine($"TV channel set to {(channel % 1 == 0 ? channel.ToString() : channel.ToString("0.0"))}");
}

class Radio : IDevice
{
    public int Volume { get; set; } = 5;
    public void PowerOn() => Console.WriteLine("Radio is powered on");
    public void PowerOff() => Console.WriteLine("Radio is powered off");
    public void SetChannel(double channel) => Console.WriteLine($"Radio frequency set to {(channel % 1 == 0 ? channel.ToString() : channel.ToString("0.0"))}");
}

interface IRemote
{
    void PowerOn();
    void PowerOff();
    void SetChannel(double channel);
    void VolumeUp();
    void VolumeDown();
}

// Bridge Implementation: Concrete Remote Implementation
class Remote(IDevice device) : IRemote
{
    private IDevice _device { get; } = device;

    public void PowerOn() => _device.PowerOn();
    public void PowerOff() => _device.PowerOff();
    public void SetChannel(double channel) => _device.SetChannel(channel);
    public void VolumeUp()
    {
        _device.Volume++;
        PrintVolume();
    }
    public void VolumeDown()
    {
        _device.Volume--;
        PrintVolume();
    }

    private void PrintVolume() => Console.WriteLine($"The volume is: {_device.Volume}");
}

// Client
class Program
{
    static void Main(string[] args)
    {
        // TV Remote
        var tv = new TV();
        var tvRemote = new Remote(tv);

        tvRemote.PowerOn();
        tvRemote.SetChannel(5);
        tvRemote.VolumeUp();
        tvRemote.PowerOff();

        // Radio Remote
        var radio = new Radio();
        var radioRemote = new Remote(radio);

        radioRemote.PowerOn();
        radioRemote.SetChannel(95.5);
        radioRemote.VolumeDown();
        radioRemote.PowerOff();
    }
}
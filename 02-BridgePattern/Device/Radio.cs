class Radio : IDevice
{
    private int _volume = 5;
    public void PowerOn() => Console.WriteLine("Radio is powered on");
    public void PowerOff() => Console.WriteLine("Radio is powered off");
    public void SetChannel(double channel) => Console.WriteLine($"Radio frequency set to {(channel % 1 == 0 ? channel.ToString() : channel.ToString("0.0"))}");
    public void SetVolume(int volume) => _volume = volume;
    public int GetVolume() => _volume;
}

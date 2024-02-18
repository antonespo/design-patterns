class TV : IDevice
{
    private int _volume = 10;
    public void PowerOn() => Console.WriteLine("TV is powered on");
    public void PowerOff() => Console.WriteLine("TV is powered off");
    public void SetChannel(double channel) => Console.WriteLine($"TV channel set to {(channel % 1 == 0 ? channel.ToString() : channel.ToString("0.0"))}");
    public void SetVolume(int volume) => _volume = volume;
    public int GetVolume() => _volume;
}

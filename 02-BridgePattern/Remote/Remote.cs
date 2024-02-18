class Remote(IDevice device) : IRemote
{
    private IDevice _device { get; } = device;

    public void PowerOn() => _device.PowerOn();
    public void PowerOff() => _device.PowerOff();
    public void SetChannel(double channel) => _device.SetChannel(channel);
    public void VolumeUp()
    {
        _device.SetVolume(_device.GetVolume() + 1);
        PrintVolume();
    }
    public void VolumeDown()
    {
        _device.SetVolume(_device.GetVolume() - 1);
        PrintVolume();
    }

    private void PrintVolume() => Console.WriteLine($"The volume is: {_device.GetVolume()}");
}

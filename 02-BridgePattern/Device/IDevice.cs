interface IDevice
{
    void PowerOn();
    void PowerOff();
    void SetChannel(double channel);
    void SetVolume(int volume);
    int GetVolume();
}

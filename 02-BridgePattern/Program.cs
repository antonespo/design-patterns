class Program
{
    static void Main(string[] args)
    {
        // TV Remote
        var tv = new TV();
        var tvRemote = new Remote(tv);

        tvRemote.PowerOn();
        tvRemote.SetChannel(5);
        tvRemote.PowerOff();
        tvRemote.VolumeUp();

        // Radio Remote
        var radio = new Radio();
        var radioRemote = new Remote(radio);

        radioRemote.PowerOn();
        radioRemote.SetChannel(95.5);
        radioRemote.PowerOff();
        radioRemote.VolumeDown();
    }
}

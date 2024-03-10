namespace IconFlyweightExample;

// Represents the intrinsic part (graphical data) of an icon
record IconType(string Name, byte[] GraphicalData);

// Represents an icon with extrinsic state (position)
class Icon(IconType type, int x, int y)
{
    public IconType Type { get; } = type;
    public int X { get; } = x;
    public int Y { get; } = y;

    public void Draw()
    {
        Console.WriteLine($"Drawing {Type.Name} at ({X}, {Y})");
        // Logic to draw the icon using Type.GraphicalData
    }
}

// Creates and returns instances of IconType
class IconFactory
{
    private readonly Dictionary<string, IconType> _iconTypes = [];

    // Gets or creates an IconType for the given name
    public IconType GetIconType(string iconName)
    {
        if (!_iconTypes.TryGetValue(iconName, out IconType? iconType))
        {
            iconType = CreateIconType(iconName);
            _iconTypes.Add(iconName, iconType);
        }
        return iconType;
    }

    // Loads graphical data for the icon type (dummy implementation)
    private byte[] LoadGraphicalData(string iconName)
    {
        Console.WriteLine($"Loading graphical data for {iconName}...");
        // Dummy implementation for loading graphical data
        return [0x01, 0x02, 0x03]; // Dummy graphical data
    }

    // Creates a new IconType
    private IconType CreateIconType(string iconName)
    {
        byte[] graphicalData = LoadGraphicalData(iconName);
        return new IconType(iconName, graphicalData);
    }
}

// Canvas to manage and render icons
class Canvas(IconFactory iconFactory)
{
    private readonly List<Icon> _icons = new List<Icon>();
    private readonly IconFactory _iconFactory = iconFactory;

    // Method to add a new icon to the canvas
    public void AddIcon(string name, int x, int y)
    {
        IconType type = _iconFactory.GetIconType(name);
        var icon = new Icon(type, x, y);
        _icons.Add(icon);
    }

    // Method to render all icons on the canvas
    public void RenderIcons() => _icons.ForEach(icon => icon.Draw());
}

class Program
{
    static void Main(string[] args)
    {
        var iconFactory = new IconFactory();
        var canvas = new Canvas(iconFactory);

        // Adding icons to the canvas with extrinsic state (position)
        canvas.AddIcon("folder", 10, 20);
        canvas.AddIcon("file", 30, 40);
        canvas.AddIcon("folder", 50, 60);

        // Rendering all icons on the canvas
        canvas.RenderIcons();
    }
}
// Component interface
interface IFileSystemItem
{
    void Print(int depth);
}

// Leaf class
class File(string name) : IFileSystemItem
{
    private string _name { get; } = name;

    public void Print(int depth)
    {
        Console.WriteLine(new string('-', depth) + _name);
    }
}

// Composite class
class Directory(string name) : IFileSystemItem
{
    private string _name { get; } = name;
    private List<IFileSystemItem> children = new List<IFileSystemItem>();

    public void AddItem(IFileSystemItem item)
    {
        children.Add(item);
    }

    public void RemoveItem(IFileSystemItem item)
    {
        children.Remove(item);
    }

    public void Print(int depth)
    {
        Console.WriteLine(new string('-', depth) + "/" + _name);

        foreach (var child in children)
        {
            child.Print(depth + 1);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create files
        var file1 = new File("file1.txt");
        var file2 = new File("file2.txt");
        var file3 = new File("file3.txt");

        // Create directories
        var dir1 = new Directory("Folder 1");
        var dir2 = new Directory("Folder 2");
        var dir3 = new Directory("Folder 3");

        // Populate directories
        dir1.AddItem(file1);
        dir1.AddItem(dir2);

        dir2.AddItem(file2);
        dir2.AddItem(file3);
        dir2.AddItem(dir3);

        // Print file system structure
        dir1.Print(0);
    }
}

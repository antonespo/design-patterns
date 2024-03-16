// Interface representing the database connection
public interface IDatabaseConnection
{
    void ExecuteQuery(string query);
}

// Real database connection
public class DatabaseConnection : IDatabaseConnection
{
    private readonly string _connectionString;

    public DatabaseConnection(string connectionString)
    {
        _connectionString = connectionString;
        // Simulate establishing a database connection
        Console.WriteLine("Establishing database connection...");
    }

    public void ExecuteQuery(string query)
    {
        // Simulate executing a query on the database
        Console.WriteLine($"Executing query: {query}");
    }
}

// Proxy for lazy initialization of the database connection
public class DatabaseConnectionProxy(string connectionString) : IDatabaseConnection
{
    private readonly string _connectionString = connectionString;
    private DatabaseConnection? _realConnection;


    public void ExecuteQuery(string query)
    {
        // Lazily initialize the real database connection
        if (_realConnection == null)
        {
            _realConnection = new DatabaseConnection(_connectionString);
        }

        // Delegate the query execution to the real connection
        _realConnection.ExecuteQuery(query);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a proxy for the database connection
        IDatabaseConnection connection = new DatabaseConnectionProxy("db_connection_string");

        // Execute queries using the proxy (connection will be lazily initialized)
        connection.ExecuteQuery("SELECT * FROM table1");
        connection.ExecuteQuery("SELECT * FROM table2");
    }
}

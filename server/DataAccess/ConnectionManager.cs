namespace DataAccess;

public class ConnectionManager
{
    private readonly string _connectionString;

    public ConnectionManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    public System.Data.SQLite.SQLiteConnection Connection => new(_connectionString);
}
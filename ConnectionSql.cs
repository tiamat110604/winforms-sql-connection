namespace TestWins.Model;

//dotnet add package MySql.Data
using MySql.Data.MySqlClient;

public class ConnectionSql
{
    private readonly string _connectionString = "server=localhost;database=student;uid=root;pwd=root";
        private MySqlConnection _conn;

    public MySqlConnection connectSql()
    {
        return new MySqlConnection(_connectionString);

    }
    public MySqlConnection GetOpenConnection()
    {
        try
        {
            var conn = new MySqlConnection(_connectionString);
            conn.Open();
            Console.WriteLine("Database connection successful");
            return conn;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine($"Database connection failed: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            return null;
        }
    }
        Console.WriteLine("Connecting to DB");

        _conn = new MySqlConnection(_connectionString);

        Console.WriteLine(_conn == null ? "Datbase Connection Failed" : "Database connection successful");

        return _conn;
    }
}

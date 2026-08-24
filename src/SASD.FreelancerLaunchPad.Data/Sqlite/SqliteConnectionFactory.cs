using Microsoft.Data.Sqlite;

namespace SASD.FreelancerLaunchPad.Data.Sqlite;

/// <summary>
/// Creates SQLite connections for the application.
/// </summary>
/// <remarks>
/// Keeping connection creation in one small class prevents connection-string
/// details from leaking into repositories or Windows Forms code.
/// </remarks>
public sealed class SqliteConnectionFactory
{
    private readonly string _connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="SqliteConnectionFactory"/> class.
    /// </summary>
    /// <param name="databasePath">Full path to the SQLite database file.</param>
    public SqliteConnectionFactory(string databasePath)
    {
        if (string.IsNullOrWhiteSpace(databasePath))
        {
            throw new ArgumentException("The database path must not be empty.", nameof(databasePath));
        }

        var builder = new SqliteConnectionStringBuilder
        {
            DataSource = databasePath,
            ForeignKeys = true
        };

        _connectionString = builder.ToString();
    }

    /// <summary>
    /// Creates and opens a new SQLite connection.
    /// </summary>
    /// <returns>An opened SQLite connection.</returns>
    public SqliteConnection CreateOpenConnection()
    {
        var connection = new SqliteConnection(_connectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = "PRAGMA foreign_keys = ON;";
        command.ExecuteNonQuery();

        return connection;
    }
}
